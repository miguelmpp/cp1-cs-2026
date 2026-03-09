// Aluno: MIGUEL PARRADO
// RM: 554007
using System.Collections.Generic;
using System.Text;

namespace SistemaGenericoCadastroWPF
{
    public class Cadastro<T>
    {
        private Dictionary<int, T> dados = new Dictionary<int, T>();

        public string Adicionar(int id, T item)
        {
            if (dados.ContainsKey(id))
            {
                return "Erro: já existe um item com esse ID.";
            }

            dados.Add(id, item);
            return "Item adicionado com sucesso!";
        }

        public string Listar()
        {
            if (dados.Count == 0)
            {
                return "Nenhum item cadastrado.";
            }

            StringBuilder sb = new StringBuilder();

            foreach (KeyValuePair<int, T> item in dados)
            {
                sb.AppendLine($"ID: {item.Key} - {item.Value}");
            }

            return sb.ToString();
        }

        public string Buscar(int id)
        {
            if (dados.ContainsKey(id))
            {
                return $"Item encontrado: ID: {id} - {dados[id]}";
            }

            return "Item não encontrado.";
        }

        public string Remover(int id)
        {
            if (dados.Remove(id))
            {
                return "Item removido com sucesso!";
            }

            return "Item não encontrado para remoção.";
        }
    }
}