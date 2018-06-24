﻿using System;
using Gcon.Website.Dominio.Entidade.Votacoes;
using Gcon.Website.Dominio.Interface;
using Npgsql;

namespace Gcon.Website.Repositorio
{
    public class VotacoesRepositorio : IVotacoes
    {
        string connectionString;

        public VotacoesRepositorio(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Inserir(Votacoes Votacoes)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
            {
                conexao.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.CommandText = string.Format("insert into \"{0}\" (\"{1}\", \"{2}\", \"{3}\", \"{4}\", \"{5}\") " +
                                         " values(@ID, @DESCRICAO, @DATA, @TITULO, @ID_PESSOA)", "VOTACOES", "ID", "DESCRICAO", "DATA", "TITULO", "ID_PESSOA");
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("ID", Votacoes.ID.ToString());
                comando.Parameters.AddWithValue("DESCRICAO", Votacoes.DESCRICAO);
                comando.Parameters.AddWithValue("DATA", Votacoes.DATA);
                comando.Parameters.AddWithValue("TITULO", Votacoes.TITULO);
                comando.Parameters.AddWithValue("ID_PESSOA", Votacoes.ID_PESSOA);

                comando.ExecuteNonQuery();
            }
        }

        public void Alterar(Votacoes Votacoes)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
            {
                conexao.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.CommandText = string.Format("UPDATE \"{0}\" " +
                                                    "SET \"{2}\" = @DESCRICAO," +
                                                        "\"{3}\" = @DATA," +
                                                        "\"{4}\" = @TITULO," +
                                                        "\"{5}\" = @ID_PESSOA " +
                                                    "WHERE \"{1}\" = @ID;", "VOTACOES", "ID", "DESCRICAO", "DATA", "TITULO", "ID_PESSOA");
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("ID", Votacoes.ID.ToString());
                comando.Parameters.AddWithValue("DESCRICAO", Votacoes.DESCRICAO);
                comando.Parameters.AddWithValue("DATA", Votacoes.DATA);
                comando.Parameters.AddWithValue("TITULO", Votacoes.TITULO);
                comando.Parameters.AddWithValue("ID_PESSOA", Votacoes.ID_PESSOA);

                comando.ExecuteNonQuery();

            }
        }

        public void Excluir(Guid id)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
            {
                conexao.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.CommandText = string.Format("DELETE FROM \"{0}\"" +
                                                           "WHERE \"{1}\" = @ID;", "VOTACOES", "ID");
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("ID", id.ToString());

                comando.ExecuteNonQuery();

            }
        }

        public Votacoes Procurar(Guid id)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
            {
                conexao.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.CommandText = string.Format("Select * from \"{0}\"" +
                                                            "WHERE \"{1}\" = @ID;", "VOTACOES", "ID");
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("ID", id.ToString());

                Votacoes Votacoes = new Votacoes();

                using (NpgsqlDataReader SqlData = comando.ExecuteReader())
                {
                    if (SqlData.Read())
                    {
                        Votacoes.ID = Guid.Parse(String.Format("{0}", SqlData["ID"]));
                        Votacoes.DESCRICAO = String.Format("{0}", SqlData["DESCRICAO"]);
                        Votacoes.DATA = (DateTime)SqlData["DATA"];
                        Votacoes.TITULO = String.Format("{0}", SqlData["TITULO"]);
                        Votacoes.ID_PESSOA = Guid.Parse(String.Format("{0}", SqlData["ID_PESSOA"]));
                    }
                }

                return Votacoes;
            }
        }
    }
}