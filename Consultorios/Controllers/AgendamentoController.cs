using Consultorios.Models.Entities;
using Consultorios.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Consultorios.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgendamentoController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly IHttpService _httpService;
        List<Agendamento> agendamento = new List<Agendamento>();


        public AgendamentoController(IEmailService emailService, IHttpService httpService)
        {
            agendamento.Add(new Agendamento { 
                Id = 1, 
                NomePaciente = "Dorivaldo dos Santos",
                Horario = new DateTime(2021, 03, 16)
            });
            this._emailService = emailService;
            this._httpService = httpService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(agendamento);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var agendamentoSelect = agendamento.FirstOrDefault(x => x.Id == id);
            return agendamentoSelect != null 
                   ? Ok(agendamento) 
                   : BadRequest("Erro ao buscar o agendamento");
        }

        [HttpPost]
        public IActionResult Post()
        {
            var pacienteAgendado = true;

            if(pacienteAgendado)
            {
               _emailService.EnviarEmail("dorivaldo@gmail.com");
            }

            return Ok();
        }

        [HttpGet]
        public IActionResult GetStatus()
        {
            _httpService.CheckStatus(false);
            return Ok();

        } 
    }
}
