namespace JogoDaForcaRemastered.ConsoleApp
{
    internal partial class Program
    {
       static string[] palavras = { "ABACATE", "ABACAXI", "ACEROLA", "AÇAÍ", "ARAÇA", "BACABA", "BACURI",
            "BANANA", "CARAMBOLA", "CUPUAÇU", "GRAVIOLA", "GOIABA", "JABUTICABA", "JENIPAPO",
            "MANGABA", "MANGA", "MARACUJÁ", "MURICI", "PEQUI", "PITANGA", "PITAYA", "SAPOTI",
            "TANGERINA","UMBO", "UVA", "UVAIA" };

        static void Main(string[] args)
        {
            JogoForca jogo = JogoForca.Inicializar(palavras);

            do
            {
                jogo.Jogar();
            } while (jogo.Running());
        }
    }
}
