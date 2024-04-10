namespace JogoDaForcaRemastered.ConsoleApp
{
    internal partial class Program
    {
        internal class JogoForca
        {
            private const int NUMERO_MAXIMO_ERROS = 5;
            public string palavraSecreta;
            public char[] letrasPalavraSecreta;
            private int quantidadeErros;
            public char[] chutes;

            public string[] palavras;
            private bool ganhou;

            private void MostrarResultado()
            {
                char input = char.ToUpper(Console.ReadKey().KeyChar);
                Console.ReadLine();
                Console.Clear();

                if (!VerificarChute(input))
                {
                    chutes[quantidadeErros] = input;
                    quantidadeErros++;
                }

                string palavraEncontrada = string.Join("", letrasPalavraSecreta);

                if (Ganhou(palavraEncontrada))
                    Console.WriteLine($"Você acertou a palavra secreta, Parabens!\nA palavra era {palavraSecreta}");

                else if (!Running()) 
                { 
                    Console.WriteLine($"Que azar! Tente novamente!\nA palavra era {palavraSecreta}");
                    Console.ReadKey();
                }
            }

            private bool Ganhou(string palavraEncontrada)
            {
                return ganhou = palavraEncontrada == palavraSecreta;
            }

            private bool VerificarChute(char letraChutada)
            {
                bool acertou = false;
                for (int i = 0; i < palavraSecreta.Length; i++)
                {
                    char letraAtual = palavraSecreta[i];

                    if (letraChutada == letraAtual)
                    {
                        letrasPalavraSecreta[i] = letraAtual;

                        acertou = true;
                    }
                }
                return acertou;
            }

            private void EscolherPalavra()
            {
                Random randomizador = new Random(); // declarando uma variavel 
                int indiceAleatorio = randomizador.Next(palavras.Length); //randomizando array
                palavraSecreta = palavras[indiceAleatorio]; //atribuindo palavra aleatoria randomizada
            }

            private void mostrarForca()
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

                Console.WriteLine(string.Join("", letrasPalavraSecreta));

                Console.WriteLine(string.Join("", chutes));

                Console.WriteLine("\n\nChute uma letra!");
            }

            public bool Running()
            {
                return quantidadeErros < NUMERO_MAXIMO_ERROS && !ganhou;
            }

            internal void Jogar()
            {
                mostrarForca();
                MostrarResultado();
            }

            internal static JogoForca Inicializar(string[] palavras)
            {
                JogoForca jogo = new JogoForca { palavras = palavras };

                jogo.chutes = new char[NUMERO_MAXIMO_ERROS];

                jogo.EscolherPalavra();

                jogo.letrasPalavraSecreta = new char[jogo.palavraSecreta.Length];
                for (int comparacaoPalavra = 0; comparacaoPalavra < jogo.letrasPalavraSecreta.Length; comparacaoPalavra++)
                    jogo.letrasPalavraSecreta[comparacaoPalavra] = '_';

                return jogo;
            }
        }
    }
}
