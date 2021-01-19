using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Cartas_Yugioh
{   static class Colecao
    {
        static List<CartasYugioh> ListaCartasYugioh;
        public static void Descerealizacao(string FilePath) //descerealizar ficheiro json
        {
            if (File.Exists(FilePath))
            {
                StreamReader FileJson = File.OpenText(FilePath); //para ler o ficheiro
                string json = FileJson.ReadToEnd(); //ler o ficheiro todo
                ListaCartasYugioh = JsonConvert.DeserializeObject<List<CartasYugioh>>(json); //descerializa um ficheiro json
                FileJson.Close();
            }
            else { Console.WriteLine("Caminho não existe!"); }
        }

        private static List<CartasYugioh> ColecaoCartasYugioh = new List<CartasYugioh>();
        public static void AdicionarCarta(int id) // adiciona cartas à coleçao 
        {
            for (int i = 0; i < ListaCartasYugioh.Count; i++)
            {
                if (ListaCartasYugioh[i].id == id)
                {
                    ColecaoCartasYugioh.Add(ListaCartasYugioh[i]);
                }
            }
        }
        public static void CriarColecaoJson(string FilePath)
        {
            string Ficheiro = FilePath + ".json";

            string serealizacao = JsonConvert.SerializeObject(ColecaoCartasYugioh.ToArray());

            StreamWriter escrever = new StreamWriter(Ficheiro);
            escrever.Write(serealizacao);
            escrever.Close();

        } // serealiza a lista da colecao cartasyugioh num ficheiro json
        public static int CartaMaiorAtaque() //retorna o maior attack da colecao
        {
           
            int numerocartasmonstro = 0;

            for (int i = 0; i < ColecaoCartasYugioh.Count; i++) //Contar as cartas monstro
            {
                if (ColecaoCartasYugioh[i].type.ToString() == "Monster")
                {
                    numerocartasmonstro += 1;
                }
            }

            if (ColecaoCartasYugioh.Count == 0)
                throw new InvalidOperationException("Erro: Adicione cartas à sua coleção!");
            else if (numerocartasmonstro == 0) // se nao existir cartas monstros na lista
                throw new InvalidOperationException("Erro: Nao existem monstros na coleção");
            else
            {
                int maiorAtaque = 0;
                for (int i = 0; i < ColecaoCartasYugioh.Count; i++)
                {
                    if (ColecaoCartasYugioh[i].atk > maiorAtaque)
                    {
                        maiorAtaque = ColecaoCartasYugioh[i].atk;

                    }
                }
                return maiorAtaque;
            }
        }
        public static int CartaMenorAtaque() //retorna o menor attack da colecao
        {
            int numerocartasmonstro = 0;

            for (int i = 0; i < ColecaoCartasYugioh.Count; i++) //Ccontar as cartas monstro
            {
                if (ColecaoCartasYugioh[i].type.ToString() == "Monster")
                {
                    numerocartasmonstro += 1;
                }
            }
            if (ColecaoCartasYugioh.Count == 0)
                throw new InvalidOperationException("Erro: Adicione cartas à sua coleção!");
            else if (numerocartasmonstro == 0) // se nao existir cartas monstros na lista
                throw new InvalidOperationException("Erro: Nao existem monstros na coleção");
            else
            {
                int menorAtaque = 10000;
                for (int i = 0; i < ColecaoCartasYugioh.Count; i++)
                {
                    if (ColecaoCartasYugioh[i].atk < menorAtaque)
                    {
                        menorAtaque = ColecaoCartasYugioh[i].atk;
                    }
                }
                return menorAtaque;
            }
        }
        public static float MediaAtaque() //retorna a media de ataque da colecao
        {
            int numerocartasmonstro = 0;

            for (int i = 0; i < ColecaoCartasYugioh.Count; i++) //contar as cartas monstro
            {
                if (ColecaoCartasYugioh[i].type.ToString() == "Monster")
                {
                    numerocartasmonstro += 1;
                }
            }

            if (ColecaoCartasYugioh.Count == 0)
                throw new InvalidOperationException("Erro: Adicione cartas à sua coleção!");
            else if (numerocartasmonstro == 0) // se nao existir cartas monstros na lista
                throw new InvalidOperationException("Erro: Nao existem monstros na coleção");
            else
            {
                float somaAtaques = 0;
                float mediaAtaques;
                for (int i = 0; i < ColecaoCartasYugioh.Count; i++)
                {
                    if (ColecaoCartasYugioh[i].type == "Monster")
                    {
                        somaAtaques += ColecaoCartasYugioh[i].atk;
                    }
                }
                mediaAtaques = somaAtaques / numerocartasmonstro;

                return mediaAtaques;
            }
        }
        public static float MediaDefesa() //retorna a media de defesa da colecao
        {
            int numerocartasmonstro = 0;

            for (int i = 0; i < ColecaoCartasYugioh.Count; i++) //Ccontar as cartas monstro
            {
                if (ColecaoCartasYugioh[i].type.ToString() == "Monster")
                {
                    numerocartasmonstro += 1;
                }
            }

            if (ColecaoCartasYugioh.Count == 0)
                throw new InvalidOperationException("Erro: Adicione cartas à sua coleção!");
            else if (numerocartasmonstro == 0) // se nao existir cartas monstros na lista
                throw new InvalidOperationException("Erro: Nao existem monstros na coleção");
            else
            {
                float mediaDefesas;
                float somadasdasdefesas = 0;
                for (int i = 0; i < ColecaoCartasYugioh.Count; i++)
                {
                    if (ColecaoCartasYugioh[i].type == "Monster")
                    {
                        somadasdasdefesas += ColecaoCartasYugioh[i].level;
                    }
                }
                mediaDefesas = somadasdasdefesas / numerocartasmonstro;
                return mediaDefesas;
            }
        }
        public static int CartaMaiorNivel() //retorna as cartas de maior nivel
        {
            int numerocartasmonstro = 0;

            for (int i = 0; i < ColecaoCartasYugioh.Count; i++) //Ccontar as cartas monstro
            {
                if (ColecaoCartasYugioh[i].type.ToString() == "Monster")
                {
                    numerocartasmonstro += 1;
                }
            }

            if (ColecaoCartasYugioh.Count == 0)
                throw new InvalidOperationException("Erro: Adicione cartas à sua coleção!");
            else if (numerocartasmonstro == 0) // se nao existir cartas monstros na lista
                throw new InvalidOperationException("Erro: Nao existem monstros na coleção");
            else
            {
                int maiornivel = 0;
                for (int i = 0; i < ColecaoCartasYugioh.Count; i++)
                {
                    if (ColecaoCartasYugioh[i].level > maiornivel)
                    {
                        maiornivel = ColecaoCartasYugioh[i].level;
                    }
                }
                return maiornivel;
            }
        }
        public static int CartaMenorNivel() //retorna o menor nivel de menor nivel
        {
            int numerocartasmonstro = 0;

            for (int i = 0; i < ColecaoCartasYugioh.Count; i++) //Ccontar as cartas monstro
            {
                if (ColecaoCartasYugioh[i].type.ToString() == "Monster")
                {
                    numerocartasmonstro += 1;
                }
            }

            if (ColecaoCartasYugioh.Count == 0)
                throw new InvalidOperationException("Erro: Adicione cartas à sua coleção!");
            else if (numerocartasmonstro == 0) // se nao existir cartas monstros na lista
                throw new InvalidOperationException("Erro: Nao existem monstros na coleção");
            else
            {
                int menornivel = 1000000;
                for (int i = 0; i < ColecaoCartasYugioh.Count; i++)
                {
                    if (ColecaoCartasYugioh[i].level < menornivel)
                    {
                        menornivel = ColecaoCartasYugioh[i].level;
                    }
                }
                return menornivel;
            }
        }
        public static float MediaNivel() // retorna a media do nivel das cartas
        {
            int numerocartasmonstro = 0;

            for (int i = 0; i < ColecaoCartasYugioh.Count; i++) //Ccontar as cartas monstro
            {
                if (ColecaoCartasYugioh[i].type.ToString() == "Monster")
                {
                    numerocartasmonstro += 1;
                }
            }

            if (ColecaoCartasYugioh.Count == 0)
                throw new InvalidOperationException("Erro: Adicione cartas à sua coleção!");
            else if (numerocartasmonstro == 0) // se nao existir cartas monstros na lista
                throw new InvalidOperationException("Erro: Nao existem monstros na coleção");
            else
            {
                float somadosnivel = 0;
                float medianivel;
                for (int i = 0; i < ColecaoCartasYugioh.Count; i++)
                {
                    if (ColecaoCartasYugioh[i].type == "Monster")
                    {
                        somadosnivel += ColecaoCartasYugioh[i].level;
                    }
                }
                medianivel = somadosnivel / ColecaoCartasYugioh.Count;
                return medianivel;
            }
        }
        public static int NumCartasSpell() //retorna o numero de cartas spell
        {
            if (ColecaoCartasYugioh.Count == 0)
                throw new InvalidOperationException("Erro: Adicione cartas à sua coleção!");
            else
            {
                int numerocartasspells = 0;

                for (int i = 0; i < ColecaoCartasYugioh.Count; i++)
                {
                    if (ColecaoCartasYugioh[i].type.ToString() == "Spell")
                    {
                        numerocartasspells += 1;
                    }
                }
                return numerocartasspells;
            }
        }
        public static int NumCartasTrap() //retorna o numero de cartas trap
        {
            int numerodecartas = 0;
            for (int i = 0; i < ColecaoCartasYugioh.Count; i++)
            {
                if (ColecaoCartasYugioh[i].type.ToString() == "Trap")
                {
                    numerodecartas += 1;
                }      
        }
            return numerodecartas;
        }
        public static int NumCartasMonstro() //retorna o numero de cartas monstro
        {
            if (ColecaoCartasYugioh.Count == 0)
                throw new InvalidOperationException("Erro: Adicione cartas à sua coleção!");
            else
            {
                int numerocartasmonstro = 0;

                for (int i = 0; i < ColecaoCartasYugioh.Count; i++)
                {
                    if (ColecaoCartasYugioh[i].type.ToString() == "Monster")
                    {
                        numerocartasmonstro += 1;
                    }
                }
                return numerocartasmonstro;
            }
        }
        public static void ImprimirCartasMonstro()//imprime as cartas que sao do tipo monstro
        {
            if (ColecaoCartasYugioh.Count == 0)
                throw new InvalidOperationException("Erro: Adicione cartas à sua coleção!");
            else
            {
                for (int i = 0; i < ColecaoCartasYugioh.Count; i++)
                {
                    if (ColecaoCartasYugioh[i].type == "Monstro")
                    {
                        Console.WriteLine(ColecaoCartasYugioh[i].name);
                        Console.WriteLine(ColecaoCartasYugioh[i].desc);
                        Console.WriteLine(ColecaoCartasYugioh[i].atk);
                        Console.WriteLine(ColecaoCartasYugioh[i].def);
                        Console.WriteLine(ColecaoCartasYugioh[i].level);
                        Console.WriteLine(ColecaoCartasYugioh[i].id);
                    }
                }
            }
        }
        public static void ImprimirCartasTrap() //imprime as cartas que sao do tipo trap
        {
            if (ColecaoCartasYugioh.Count == 0)
                throw new InvalidOperationException("Erro: Adicione cartas à sua coleção!");
            else
            {
                for (int i = 0; i < ColecaoCartasYugioh.Count; i++)
                {
                    if (ColecaoCartasYugioh[i].type == "Trap")
                    {
                        Console.WriteLine(ColecaoCartasYugioh[i].name);
                        Console.WriteLine(ColecaoCartasYugioh[i].desc);
                        Console.WriteLine(ColecaoCartasYugioh[i].atk);
                        Console.WriteLine(ColecaoCartasYugioh[i].def);
                        Console.WriteLine(ColecaoCartasYugioh[i].level);
                        Console.WriteLine(ColecaoCartasYugioh[i].id);
                    }
                }
            }
        }
        public static void ImprimirCartasSpell() //imprime as cartas que sao do tipo trap
        {
            if (ColecaoCartasYugioh.Count == 0)
                throw new InvalidOperationException("Erro: Adicione cartas à sua coleção!");
            else
            {
                for (int i = 0; i < ColecaoCartasYugioh.Count; i++)
                {
                    if (ColecaoCartasYugioh[i].type == "Spell")
                    {
                        Console.WriteLine(ColecaoCartasYugioh[i].name);
                        Console.WriteLine(ColecaoCartasYugioh[i].desc);
                        Console.WriteLine(ColecaoCartasYugioh[i].atk);
                        Console.WriteLine(ColecaoCartasYugioh[i].def);
                        Console.WriteLine(ColecaoCartasYugioh[i].level);
                        Console.WriteLine(ColecaoCartasYugioh[i].id);
                    }
                }
            }
        }

    }
}
