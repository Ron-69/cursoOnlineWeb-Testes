using System;
using CursoOnline.Dominio.Cursos;
using CursoOnline.Dominio.PublicosAlvo;

namespace CursoOnline.DominioTest._Builders
{
    public class CursoBuilder //Este são valores default para o builder toda vez que um curso novo for criado
    {
        private string _nome = "Informática básica";
        private double _cargaHoraria = 80;
        private PublicoAlvo _publicoAlvo = PublicoAlvo.Estudante;
        private double _valor = 950;
        private string _descricao = "Uma descrição";
        private int _id;

        public static CursoBuilder Novo()
        {
            return new CursoBuilder();
        }

        public CursoBuilder ComNome(string nome)
        {
            _nome = nome;
            return this;
        }

        public CursoBuilder ComDescricao(string descricao)
        {
            _descricao = descricao;
            return this;
        }

        public CursoBuilder ComCargaHoraria(double cargaHoraria)
        {
            _cargaHoraria = cargaHoraria;
            return this;
        }

        public CursoBuilder ComValor(double valor)
        {
            _valor = valor;
            return this;
        }

        public CursoBuilder ComPublicoAlvo(PublicoAlvo publicoAlvo)
        {
            _publicoAlvo = publicoAlvo;
            return this;
        }

        public CursoBuilder ComId(int id)
        {
            _id = id;
            return this;
        }

        public Curso Build()
        {
            var curso = new Curso(_nome, _descricao, _cargaHoraria, _publicoAlvo, _valor);

            if (_id > 0)//só quando o Id for maior que zero
            {
                var propertyInfo = curso.GetType().GetProperty("Id"); //Pegando tipo do curso e pela proriedade Id
                propertyInfo.SetValue(curso, Convert.ChangeType(_id, propertyInfo.PropertyType), null);//Através de reflection setamos o valor do Id
            }
            
            return curso;
        }
    }
}
