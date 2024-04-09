using System.Runtime.Serialization.Formatters;

namespace ConsoleApp1
{
    internal class Program
    {

        static void Main(string[] args)
        {

            int quantidadeErros = 0;

            bool jogadorAcertou = false;
            bool jogadorEnforcou = false;


            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("|Bem vindo ao Jogo da forca! | Academia Do Programador 2024|");
            Console.WriteLine("------------------------------------------------------------");

            string[] palavras = { "ABACATE", "ABACAXI", "ACEROLA", "AÇAÍ", "ARAÇA", "BACABA", "BACURI",
                "BANANA", "CARAMBOLA", "CUPUAÇU", "GRAVIOLA", "GOIABA", "JABUTICABA", "JENIPAPO",
                "MANGABA", "MANGA", "MARACUJÁ", "MURICI", "PEQUI", "PITANGA", "PITAYA", "SAPOTI",
                "TANGERINA","UMBO", "UVA", "UVAIA" };

            string palavraSecreta;
            char[] letrasPalavraSecreta;

            //Randomizador palavras
            Random randomizador = new Random(); // declarando uma variavel 
            int indiceAleatorio = randomizador.Next(palavras.Length); //randomizando array
            palavraSecreta = palavras[indiceAleatorio]; //atribuindo palavra aleatoria randomizada

            letrasPalavraSecreta = new char[palavraSecreta.Length];
            for (int comparacaoPalavra = 0; comparacaoPalavra < letrasPalavraSecreta.Length; comparacaoPalavra++)
                letrasPalavraSecreta[comparacaoPalavra] = '_';

            do
            {
                string cabecaErro = quantidadeErros >= 1 ? "o" : " ";
                string corpoErro = quantidadeErros >= 2 ? "x" : " ";
                string bracoEsquerdoErro = quantidadeErros >= 3 ? "/" : " ";
                string bracoDireitoErro = quantidadeErros >= 3 ? @"\" : " ";
                string pernaEsquerdaErro = quantidadeErros >= 4 ? "/" : " ";
                string pernaDireitaErro = quantidadeErros >= 4 ? @" \" : " ";

                Console.Clear();
                Console.WriteLine(" ___________        ");
                Console.WriteLine(" |/        |        ");
                Console.WriteLine(" |         {0}       ", cabecaErro);
                Console.WriteLine(" |        {0}{1}{2} ", bracoEsquerdoErro, corpoErro, bracoDireitoErro);
                Console.WriteLine(" |        {0}{1}       ", pernaEsquerdaErro, pernaDireitaErro);
                Console.WriteLine(" | ");
                Console.Write(" | ");

                Console.Write("\n" + string.Join("", letrasPalavraSecreta));

                Console.WriteLine("\n\nChute uma letra!"); // Input letra chutada.
                char letraChutada = Console.ReadLine()[0]; // Atribuição letra chutada.

                //Comparar input letra chutada e atribuir ao espaço underline
                bool letraFazParteDaPalavra = false;

                for (int i = 0; i < palavraSecreta.Length; i++)
                {
                    char letraAtual = palavraSecreta[i];

                    if (letraChutada == letraAtual)
                    {
                        letrasPalavraSecreta[i] = letraAtual;
                        letraFazParteDaPalavra = true;
                    }
                }
                if (letraFazParteDaPalavra == false)
                    quantidadeErros++;

                string palavraEncontrada = string.Join("", letrasPalavraSecreta);

                jogadorAcertou = palavraEncontrada == palavraSecreta;
                jogadorEnforcou = quantidadeErros >= 5;

                if (jogadorAcertou)
                    Console.WriteLine("\n Você acertou a palavra secreta, Parabens!");

                else if (jogadorEnforcou)
                    Console.WriteLine("\n Que azar! Tente novamente!");
            } while (jogadorEnforcou == false && jogadorAcertou == false);

            Console.ReadLine();
        }
    }
}