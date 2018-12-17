using System;
using System.Linq;
using System.IO;
using Xpto.Persistencia.Context;
using Xpto.Modelo;

namespace Xpto.Persistencia
{
    public class ExtrairDados
    {
        private EFContext db = new EFContext();

        public void ExtrairDadosArquivo_1(string caminho)
        {
            try
            {
                //var caminho = System.Web.HttpContext.Current.Server.MapPath(@"~/Arquivos").Replace('\\', '/');
                //var arquivo = new StreamReader(caminho + @"/" + "ARQUIVO1-PLENO.txt");

                var arquivo = new StreamReader(caminho);
                string linha;

                while ((linha = arquivo.ReadLine()) != null)
                {
                    var clientes = linha.Split(new[] { ",", ";" }, StringSplitOptions.RemoveEmptyEntries);

                    var idArquivo = string.Empty;
                    var nome = string.Empty;
                    var sobrenome = string.Empty;
                    var dataNascimento = string.Empty;
                    var sexo = string.Empty;
                    var email = string.Empty;
                    var ativo = string.Empty;

                    foreach (var cli in clientes)
                    {
                        if (string.IsNullOrEmpty(idArquivo))
                        {
                            idArquivo = cli;
                        }

                        else if (string.IsNullOrEmpty(nome))
                        {
                            nome = cli;
                        }

                        else if (string.IsNullOrEmpty(sobrenome))
                        {
                            sobrenome = cli;
                        }

                        else if (string.IsNullOrEmpty(dataNascimento))
                        {
                            dataNascimento = cli;
                        }

                        else if (string.IsNullOrEmpty(sexo))
                        {
                            sexo = cli;
                        }

                        else if (string.IsNullOrEmpty(email))
                        {
                            email = cli;
                        }

                        else if (string.IsNullOrEmpty(ativo))
                        {
                            ativo = cli;
                        }

                        if (!string.IsNullOrEmpty(idArquivo) &&
                            !string.IsNullOrEmpty(nome) &&
                            !string.IsNullOrEmpty(sobrenome) &&
                            !string.IsNullOrEmpty(dataNascimento) &&
                            !string.IsNullOrEmpty(sexo) &&
                            !string.IsNullOrEmpty(email) &&
                            !string.IsNullOrEmpty(ativo))
                        {
                            var cliente = new Cliente
                            {
                                IdArquivo = int.Parse(idArquivo),
                                Nome = nome + " " + sobrenome,
                                DataNascimento = Convert.ToDateTime(dataNascimento),
                                Sexo = sexo,
                                Email = email,
                                Ativo = Convert.ToBoolean(ativo)
                            };

                            db.Clientes.Add(cliente);
                            db.SaveChanges();

                            idArquivo = string.Empty;
                            nome = string.Empty;
                            sobrenome = string.Empty;
                            dataNascimento = string.Empty;
                            sexo = string.Empty;
                            email = string.Empty;
                            ativo = string.Empty;
                        }
                    }
                }

                arquivo.Close();
            }
            catch (Exception ex)
            {
                ex.Mensagem();             
            }
        }

        public void ExtrairDadosArquivo_2(string caminho)
        {
            ExtrairDadosProduto(caminho);
            ExtrairDadosClienteProduto(caminho);
        }

        private void ExtrairDadosProduto(string caminho)
        {
            try
            {
                //var caminho = System.Web.HttpContext.Current.Server.MapPath(@"~/Arquivos").Replace('\\', '/');
                //var arquivo = new StreamReader((caminho + @"/" + "ARQUIVO2-PLENO.txt"));

                var arquivo = new StreamReader(caminho);
                string linha;

                while ((linha = arquivo.ReadLine()) != null)
                {
                    var produtos = linha.Split(new[] { ",", ";" }, StringSplitOptions.RemoveEmptyEntries);

                    var idArquivo = string.Empty;
                    var idCliente = string.Empty;
                    var descricaoProduto = string.Empty;

                    foreach (var prod in produtos)
                    {
                        if (string.IsNullOrEmpty(idArquivo))
                        {
                            idArquivo = prod;
                        }

                        else if (string.IsNullOrEmpty(idCliente))
                        {
                            idCliente = prod;
                        }

                        else if (string.IsNullOrEmpty(descricaoProduto))
                        {
                            descricaoProduto = prod;
                        }

                        if (!string.IsNullOrEmpty(idArquivo) && !string.IsNullOrEmpty(descricaoProduto))
                        {
                            var produto = new Produto
                            {
                                IdArquivo = int.Parse(idArquivo),
                                Descricao = descricaoProduto
                            };

                            var cadastrado = db.Produtos.Where(p => p.Descricao == produto.Descricao).ToList();

                            if (cadastrado.Count() == 0)
                            {
                                db.Produtos.Add(produto);
                                db.SaveChanges();
                            }

                            idArquivo = string.Empty;
                            idCliente = string.Empty;
                            descricaoProduto = string.Empty;
                        }
                    }
                }

                arquivo.Close();
            }
            catch (Exception ex)
            {                
                ex.Mensagem();
            }
        }

        private void ExtrairDadosClienteProduto(string caminho)
        {
            try
            {
                //var caminho = System.Web.HttpContext.Current.Server.MapPath(@"~/Arquivos").Replace('\\', '/');
                //var arquivo = new StreamReader(caminho + @"/" + "ARQUIVO2-PLENO.txt");

                var arquivo = new StreamReader(caminho);
                string linha;

                while ((linha = arquivo.ReadLine()) != null)
                {
                    var produtos = linha.Split(new[] { ",", ";" }, StringSplitOptions.RemoveEmptyEntries);

                    var idProduto = 0;
                    var idCliente = 0;
                    var descricaoProduto = string.Empty;

                    foreach (var prod in produtos)
                    {
                        if (idProduto == 0)
                        {
                            idProduto = int.Parse(prod);
                        }

                        else if (idCliente == 0)
                        {
                            idCliente = int.Parse(prod);
                        }

                        else if (string.IsNullOrEmpty(descricaoProduto))
                        {
                            descricaoProduto = prod;
                        }

                        if (idProduto > 0 && idCliente > 0 && !string.IsNullOrEmpty(descricaoProduto))
                        {
                            var cliente = db.Clientes.Where(c => c.IdArquivo == idCliente).SingleOrDefault();
                            var produto = db.Produtos.Where(c => c.IdArquivo == idProduto).SingleOrDefault();

                            var clienteProduto = new ClienteProduto
                            {
                                Cliente = cliente,
                                ClienteId = cliente.Id,
                                Produto = produto,
                                ProdutoId = produto.Id
                            };

                            db.ClientesProdutos.Add(clienteProduto);
                            db.SaveChanges();

                            idProduto = 0;
                            idCliente = 0;
                            descricaoProduto = string.Empty;
                        }
                    }
                }

                arquivo.Close();
            }
            catch (Exception ex) 
            {                
                ex.Mensagem();
            }
        }
    }
}