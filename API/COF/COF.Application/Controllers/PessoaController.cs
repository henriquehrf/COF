using COF.Domain.Interfaces.Services;
using COF.Domain.Interfaces.UnitOfWork;
using COF.Domain.Models;
using COF.Infra.Shared.NotificationContext;
using COF.Infra.Shared.ObjectMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace COF.Application.Controllers
{
	//[Authorize]
	[ApiController]
	[Route("api/[controller]/")]
	public class PessoaController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IPessoaService _pessoaService;
		private readonly NotificationContext _notificationContext;

		public PessoaController(IUnitOfWork unitOfWork, IPessoaService pessoaService, NotificationContext notificationContext)
		{
			_unitOfWork = unitOfWork;
			_pessoaService = pessoaService;
			_notificationContext = notificationContext;
		}

		[HttpPost("inserir-pessoa")]
		public IActionResult InserirPessoa(PessoaModel pessoaModel)
		{
			try
			{
				var pessoa = _pessoaService.InserirPessoa(pessoaModel.ToEntity());
				if (_notificationContext.Notifications.Count > 0)
					return BadRequest(_notificationContext.Notifications);

				_unitOfWork.Commit();
				return StatusCode(StatusCodes.Status201Created, pessoa.ToModel());
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex);
			}
		}

		[HttpPut("alterar-pessoa")]
		public IActionResult AlterarPessoa(PessoaModel pessoaModel)
		{
			try
			{
				var pessoa = _pessoaService.AlterarPessoa(pessoaModel.ToEntity());
				if (_notificationContext.Notifications.Count > 0)
					return BadRequest(_notificationContext.Notifications);

				_unitOfWork.Commit();
				return StatusCode(StatusCodes.Status200OK, pessoa.ToModel());
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[HttpDelete("excluir-pessoa")]
		public IActionResult ExcluirPessoa(int id)
		{
			try
			{
				var pessoa = _pessoaService.ExcluirPessoa(id);
				if (_notificationContext.Notifications.Count > 0)
					return NotFound(_notificationContext.Notifications);

				_unitOfWork.Commit();
				return StatusCode(StatusCodes.Status200OK, pessoa.ToModel());
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}
	}
}
