using CatalogoJogos.api.InputModel;
using CatalogoJogos.api.ViemModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoJogos.api.Services
{
    public interface IJogoService:IDisposable
    {
        Task<List<JogoViewModel>> Obter(int pagina, int quantidade);
        Task<JogoViewModel> Obter(Guid Id);
        Task<JogoViewModel> Inserir(JogoInputModel jogo);
        Task Atualizar(Guid Id, JogoInputModel jogo);
        Task Atualizar(Guid Id, decimal preco);
        Task Remover(Guid Id);

    }
}
