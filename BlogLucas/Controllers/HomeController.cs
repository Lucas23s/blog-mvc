using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BlogLucas.Models;

namespace BlogLucas.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private List<Postagem> postagens;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        List<Categoria> categorias = [
    new() { Id = 1, Nome = "filmes" }
];
        postagens = [
            new() {
                Id = 1,
                Nome = "O Mundo de Gumball: Nova série ganha data de estreia",
                CategoriaId = 1,
                Categoria = categorias.Find(c => c.Id == 1),
                DataPostagem = DateTime.Parse("30/06/2025"),
                Descricao = "A próxima temporada de O Mundo de Gumball teve a sua nova abertura revelada pelo Cartoon Network - assista.",
                Texto = "<strong>O Incrível Mundo de Gumball</strong>, a adora série animada do Cartoon Network, está prestes a retornar com uma nova temporada.<br>Após conquistar o público com seu humor afiado e situações pra lá de criativas, agora teremos uma 6ª temporada. No entanto, houve uma troca de título para <strong>O Estranhamente Maravilhoso Mundo de Gumball</strong>.",
                Thumbnail = "/img/1.png",
                Foto = "/img/1.png"
            },
            new() {
                Id = 2,
                Nome = "O Gatola da Cartola: Trailer da animação será lançado amanhã",
                CategoriaId = 1,
                Categoria = categorias.Find(c => c.Id == 1),
                DataPostagem = DateTime.Parse("30/06/2025"),
                Descricao = "Amanhã a Warner irá lançar o primeiro trailer de O Gatola da Cartola, e você pode conferir o anúncio agora!",
                Texto = "<strong>O Gatola da Cartola</strong> está ganhando uma nova adaptação para o cinema! Desta vez, trata-se de uma animação produzida pela Warner.<br>A nova adaptação do clássico de Dr. Seuss chegará aos cinemas em fevereiro de 2026, e o comediante <strong>Bill Hader</strong> é quem dará voz ao protagonista.",
                Thumbnail = "/img/2.png",
                Foto = "/img/2.png"
            },
            new() {
                Id = 3,
                Nome = "Smurfs: O novo filme irá flopar? Veja a previsão de bilheteria",
                CategoriaId = 1,
                Categoria = categorias.Find(c => c.Id == 1),
                DataPostagem = DateTime.Parse("30/06/2025"),
                Descricao = "Os Smurfs terão um novo filme lançado em julho. Mas será que ele irá flopar? Veja a primeira previsão de bilheteria.",
                Texto = "<strong>Smurfs</strong>, marcado para chegar aos cinemas no dia 17 de julho, é o novo filme da adorado grupinho azul.<br>A mais nova tentativa de revitalizar a franquia irá misturar animação e live-action. Além disso, a produção conta com Rihanna dando voz a Smurfete, além de também apresentar uma canção original.",
                Thumbnail = "/img/3.png",
                Foto = "/img/3.png"
            },
            new() {
                Id = 4,
                Nome = "Como Treinar o Seu Dragão tem nova atualização de bilheteria",
                CategoriaId = 1,
                Categoria = categorias.Find(c => c.Id == 1),
                DataPostagem = DateTime.Parse("29/06/2025"),
                Descricao = "A bilheteria de Como Treinar o Seu Dragão recebe uma nova atualização - saiba mais",
                Texto = "<strong>Como Treinar o Seu Dragão</strong>, sem muita surpresa, vem conquistando bons números de bilheteria para a Universal/Dreamworks.<br>Após três semanas em exibição, o filme agora soma <strong>US$ 450 milhões de dólares</strong> mundialmente. Vale lembrar que o filme custou US$ 150 milhões para ser produzido.",
                Thumbnail = "/img/4.png",
                Foto = "/img/4.png"
            }
        ];
    }

    public IActionResult Index()
    {
        return View(postagens);
    }

    public IActionResult Postagem(int id)
    {
        var postagem = postagens
            .Where(p => p.Id == id)
            .SingleOrDefault();
        if (postagem == null)
            return NotFound();
        return View(postagem);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
