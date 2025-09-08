using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gerenciador_Tarefas_SemSQL.Models
{
    public class Tarefas
    {
        List<Tarefas> listaTarefasTitulo = new List<Tarefas>();
        List<Tarefas> listaTarefasObservacao = new List<Tarefas>();
        public string? Titulo { get; set; }
        public string? Observação { get; set; }

        public void AdicionarTituloTarefa(string titulos)
        {
            Titulo = titulos;
            listaTarefasTitulo.Add(new Tarefas() { Titulo = titulos });
            Console.WriteLine($"Tarefa adicionada com sucesso com o título: {Titulo}");
        }

        public void ListarTarefas()
        {
            Console.WriteLine("Lista de Tarefas:");
            for (int i = 0; i < listaTarefasTitulo.Count; i++)
            {
                Console.WriteLine($"{i + 1}ª Tarefa: {listaTarefasTitulo[i].Titulo}");
            }
        }

        public void RemoverTarefa()
        {
            ListarTarefas();
            Console.WriteLine("Digite o número da tarefa que deseja remover:");
            int numeroTarefa = int.Parse(Console.ReadLine()!);
            if (numeroTarefa > 0 && numeroTarefa <= listaTarefasTitulo.Count)
            {
                listaTarefasTitulo.RemoveAt(numeroTarefa - 1);
                Console.WriteLine("Tarefa removida com sucesso!");
            }
            else
            {
                Console.WriteLine("Número de tarefa inválido.");
            }
        }

    }
}