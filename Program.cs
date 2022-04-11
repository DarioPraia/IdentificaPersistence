using IdentificaPersistence.Persistence;
using IdentificaPersistence.Core.Domain;

int option = 0;

while (option > -1)
{
    switch (option)
    {
        case 0:
            Console.WriteLine("###########################################################");
            Console.WriteLine("##                     IDENTIFICACAO                     ##");
            Console.WriteLine("###########################################################");
            Console.WriteLine("1- Novo Registro");
            Console.WriteLine("2- Consultar");
            Console.WriteLine("0- Fechar");
            Console.Write("\nSeleccione um opcao: ");

            var op = Console.ReadLine();

            Int32.TryParse(op, out option);

            option = option != 0 ? option : -1;
        break;
        case 1:
            Console.Clear();
            Console.WriteLine("###########################################################");
            Console.WriteLine("##                     IDENTIFICACAO                     ##");
            Console.WriteLine("###########################################################");
            Console.WriteLine("##                     NOVO REGISTRO                     ##");
            
            var Pessoa = new Pessoa();

            Console.Write("Nome: ");
            Pessoa.Name = Console.ReadLine();

            Console.Write("Nome do Pai: ");
            Pessoa.NomePai = Console.ReadLine();

            Console.Write("Nome da Mae: ");
            Pessoa.NomeMae = Console.ReadLine();

            Console.Write("Data de Nascimento(dd-mm-yyyy): ");
            Pessoa.DataNasecimento = DateTime.Parse(Console.ReadLine());
            
            using (var context = new UnitOfWork(new IdentificacaoContext()))
            {
                var identificacao = new Identificacao() {
                    Pessoa = Pessoa,
                    Numero = RandomString(14)
                };

                context.Identificacoes.Add(identificacao);
                context.Complete();

                Console.WriteLine("Registro salvo com sucesso");
            }

            Console.WriteLine("1- Voltar ao menu");
            Console.WriteLine("0- Fechar");

            Console.Write("\nSeleccione um opcao: ");

            op = Console.ReadLine();

            Int32.TryParse(op, out option);
            option = (option > 0) ? 0 : -1;
        break;
        case 2: 
            Console.WriteLine("###########################################################");
            Console.WriteLine("##                     IDENTIFICACAO                     ##");
            Console.WriteLine("###########################################################");
            Console.WriteLine("##                       CONSULTAR                       ##");
            
            Console.Write("Numero de registro: ");
            string numero = Console.ReadLine();
            
            using (var context = new UnitOfWork(new IdentificacaoContext()))
            {
                Identificacao identificacao = context.Identificacoes.GetIdentificacaoPeloNumero(numero); 

                if (identificacao != null)
                {
                    String str = $"\nNome: {identificacao.Pessoa.Name}\nPai: {identificacao.Pessoa.NomePai}\nMae: {identificacao.Pessoa.NomeMae}\nData de Nascimento: {identificacao.Pessoa.DataNasecimento.ToString("dd-MM-yyyy")}";
                    Console.WriteLine(str);
                }
                else
                {
                    Console.WriteLine("Não encontrado");
                }                
            }

            Console.WriteLine("\n1- Voltar ao menu");
            Console.WriteLine("0- Fechar");

            Console.Write("\nSeleccione um opcao: ");

            op = Console.ReadLine();

            Int32.TryParse(op, out option);
            option = (option > 0) ? 0 : -1;
        break; 
    }  

    Console.Clear();
}


static string RandomString(int length)
{
    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    return new string(Enumerable.Repeat(chars, length)
        .Select(s => s[new Random().Next(s.Length)]).ToArray());
}