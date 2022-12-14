namespace GestaoHospilar
{
    public class PagavelHospital
    {
        public List<IRecebedor> Recebedores { get; private set; }

        public PagavelHospital()
        {
            Recebedores = new List<IRecebedor>();
        }

        public void Adicionar(IRecebedor recebedor)
        {
            var index = Recebedores.FindIndex(x => x.Identificador.Equals(recebedor.Identificador));
            if (index != -1)
                throw new Exception("Recebedor já existente");

            Recebedores.Add(recebedor);
        }

        public void Remover(string identificacao)
        {
            var index = Recebedores.FindIndex(x => x.Identificador.Equals(identificacao));
            if (index == -1)
                throw new Exception("Recebedor não existe");

            Recebedores.RemoveAt(index);
        }

        public IRecebedor Buscar(string identificacao)
        {
            var index = Recebedores.FindIndex(x => x.Identificador.Equals(identificacao));
            if (index == -1)
                throw new Exception("Recebedor não existe");

            return Recebedores[index];
        }
    }
}