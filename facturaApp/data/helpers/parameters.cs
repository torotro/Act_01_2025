namespace facturaApp.data.helpers
{
    public class parameters
    {
        public string Name { get; set; }
        public object Valor { get; set; }

        public parameters(string name, object valor)
        {
            this.Name = name;
            this.Valor = valor;
        }

        public parameters()
        {
        }
    }
}