using CatalogoJogos.api.InputModel;
using CatalogoJogos.api.Services;
using CatalogoJogos.api.ViemModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoJogos.api.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private readonly IJogoService _jogoService;

        public JogosController(IJogoService jogoService)
        {
            _jogoService = jogoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<JogoViewModel>>> Obter([FromQuery, Range(1, int.MaxValue)] int pagina = 1, [FromQuery, Range(1, 50)] int quantidade = 5)
        {
            var jogos = await _jogoService.Obter(pagina, quantidade);
            if (jogos.Count() == 0)
                return NoContent();

            return Ok(jogos);
        }

        [HttpGet("{idJogo:guid")]
        public async Task<ActionResult<JogoViewModel>> Obter([FromRoute] Guid idJogo)
        {
            var jogo = await _jogoService.Obter(idJogo);

            if (jogo == null)
                return NoContent();

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<JogoViewModel>> InserirJogo([FromBody] JogoInputModel jogoInputModel)
        {
            try
            {
                var jogo = await _jogoService.Inserir(jogoInputModel);

                return Ok();
            }
            //catch (JogoCadastradoException ex)
            catch (Exception ex)
            {
                return UnprocessableEntity("Já existe um jogo com este nome para está produtora");
            }

        }

        [HttpPut("{idJogo:guid")]
        public async Task<ActionResult> AtualizarJogo([FromBody] Guid idJogo, [FromBody] JogoInputModel jogoInputModeljogo)
        {
            try
            {
                await _jogoService.Atualizar(idJogo, jogoInputModeljogo);

                return Ok();
            }
            //catch (JogoNaoCadastradoException ex)
            catch (Exception ex)
            {
                return NotFound("Não existe este jogo");
            }


        }

        [HttpPatch("{idJogo:guid/preco/{preco:double")]
        public async Task<ActionResult> AtualizarJogo([FromRoute]Guid idJogo, [FromRoute]double preco)
        {
            try
            {
                await _jogoService.Atualizar(idJogo, preco);
                return Ok();
            }
            //catch (JogoNaoCadastradoException ex)
            catch (Exception ex)
            {
                return NotFound("Não existe este jogo");
            }
        }

        [HttpDelete("{idJogo:guid")]
        public async Task<ActionResult> ApagarJogo([FromRoute] Guid idJogo)
        {
            try
            {
                await _jogoService.Remover(idJogo);
                return Ok();

            }
            //catch (JogoNaoCadastradoException ex)
            catch (Exception)
            {
                return NotFound("Não existe este jogo");
            }
        }

    }
}
