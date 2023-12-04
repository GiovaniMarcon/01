internal class Program
{
    Program()
        { 
            try
            {
                string textoCifrado = File.ReadAllText("provinhaBarbadinha.txt");
                string textoDecifrado = DeTeusPulos(textoCifrado);

                textoDecifrado = textoDecifrado.Replace("@", "\n");

                string[] palavras = textoDecifrado.Split("");

                List<string> palindromos = RetornaPalindromos(palavras);

                int auxIndice = 0;
                string[] auxSubstitui = ["palavra1", "palavra2", "palavra3"];
                    foreach (var palindromo in palindromos)
                    {
                        textoDecifrado = textoDecifrado.Replace(palindromo, auxSubstitui[auxIndice++]);
                    }

                Console.WriteLine($"Conteúdo Cifrado: {textoCifrado}\n");
                Console.WriteLine($"Palindromos encontrados: {String.Join(",", palindromos)}\n");
                Console.WriteLine($"Caracteres: {palavras.Length}\n");
                Console.WriteLine($"Texto Decifrado: {textoDecifrado.ToUpper()}\n");
                }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public string DeTeusPulos(string cifrado)
        {
            StringBuilder auxDecifra = new("");

            for(int indice = 0; indice < cifrado.Length; indice++)
            {
                auxDecifra.Append((char)((int)cifrado[indice] - ((indice % 5 == 0) ? 8 : 16)));
            }
            return auxDecifra.ToString();
        
        }
     
        public List<string> RetornaPalindromos(string[]palavras)
        {
            List<string> auxRetorno = new();

            for (int i = 0; i < palavras.Length; i++)
            {
                if (palavras[i].Equals(new(palavras[i].Reverse().ToArray())) && palavras[i].Length > 1)
                {
                    auxRetorno.Add(palavras[i]);
                }
            }
            return auxRetorno;
        }

        private static void Main()
        {
            _=new Program();
        }
}