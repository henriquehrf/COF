using COF.Domain.Interfaces.Repository;
using COF.Domain.Interfaces.Services;
using COF.Domain.Interfaces.UnitOfWork;
using COF.Domain.Models;
using COF.Infra.CrossCutting.Filter;
using COF.Infra.Shared.NotificationContext;
using COF.Infra.Shared.ObjectMapper;
using Flunt.Notifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace COF.Application.Controllers
{
	//[Authorize]
	[ApiController]
	[Route("api/[controller]/")]
	public class PessoaController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IPessoaService _pessoaService;
		private readonly IPessoaRepository _pessoaRepository;
		private readonly NotificationContext _notificationContext;

		public PessoaController(IUnitOfWork unitOfWork, IPessoaService pessoaService, IPessoaRepository pessoaRepository, NotificationContext notificationContext)
		{
			_unitOfWork = unitOfWork;
			_pessoaService = pessoaService;
			_pessoaRepository = pessoaRepository;
			_notificationContext = notificationContext;
		}

		[HttpPost("inserir-pessoa")]
		[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PessoaViewModel))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IList<NotificationResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErroResponse))]
		public IActionResult InserirPessoa(PessoaViewModel pessoaVm)
		{
			var pessoa = _pessoaService.InserirPessoa(pessoaVm.ToEntity());
			if (_notificationContext.Notifications.Count > 0)
				return BadRequest(_notificationContext.Notifications);

			_unitOfWork.Commit();
			return StatusCode(StatusCodes.Status201Created, pessoa.ToModel());

		}

		[HttpPut("alterar-pessoa")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IList<NotificationResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErroResponse))]
		public IActionResult AlterarPessoa(PessoaViewModel pessoaVm)
		{
			try
			{
				_pessoaService.AlterarPessoa(pessoaVm.ToEntity());
				if (_notificationContext.Notifications.Count > 0)
					return BadRequest(_notificationContext.Notifications);

				_unitOfWork.Commit();
				return StatusCode(StatusCodes.Status200OK);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[HttpDelete("excluir-pessoa")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(IList<NotificationResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErroResponse))]
		public IActionResult ExcluirPessoa(int id)
		{

			_pessoaService.ExcluirPessoa(id);
			if (_notificationContext.Notifications.Count > 0)
				return NotFound(_notificationContext.Notifications);

			_unitOfWork.Commit();
			return StatusCode(StatusCodes.Status204NoContent);
		}

		[HttpGet("buscar-todas-pessoas")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginacaoViewModel<PessoaViewModel>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErroResponse))]
		public IActionResult BuscarTodasPessoas([FromQuery] RecursoPaginacaoViewModel paginacao)
		{

			var pessoas = PaginacaoViewModel<PessoaViewModel>.From(_pessoaRepository.Todos(),
																	objMapper: PessoaMapper.ToEnumerableModel,
																	paginaAtual: paginacao.Pagina,
																	tamanhoPagina: paginacao.TamanhoPagina);
			return StatusCode(StatusCodes.Status200OK, pessoas);
		}
	}
}
