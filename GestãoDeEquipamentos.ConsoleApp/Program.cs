using System.Collections;
using System.ComponentModel;

internal class Program
{
    static string comandoPrimeiroMenu = "";
    static string comandoSegundoMenu = "";
    static string comandoPrincipal = "";
    static int ContadorChamados = 0;
    static ArrayList NomesEquipamentos = new ArrayList();
    static ArrayList PrecoEquipamentos = new ArrayList();
    static ArrayList NumeroSerie = new ArrayList();
    static ArrayList DataFabricacao = new ArrayList();
    static ArrayList Fabricante = new ArrayList();
    static ArrayList IdsEquipamento = new ArrayList();
    static ArrayList TituloChamados = new ArrayList();
    static ArrayList DescricoesChamados = new ArrayList();
    static ArrayList EquipamentosChamados = new ArrayList();
    static ArrayList DataAberturaChamado = new ArrayList();
    static ArrayList IdsChamado = new ArrayList();
    static int EquipamentosAdicionados = 0;

    private static void Main(string[] args)
    {
        NomesEquipamentos.Add("Impressora");
        IdsEquipamento.Add(0);
        NumeroSerie.Add(001);
        PrecoEquipamentos.Add(2000);
        Fabricante.Add("HP");
        DataFabricacao.Add("24/12/2007");

        NomesEquipamentos.Add("Notebook");
        IdsEquipamento.Add(1);
        NumeroSerie.Add(002);
        PrecoEquipamentos.Add(5000);
        Fabricante.Add("Acer");
        DataFabricacao.Add("02/02/2012");



        //chamados

        IdsChamado.Add(0);
        DescricoesChamados.Add("impressora estragou");
        TituloChamados.Add("Impressora ruim");
        EquipamentosChamados.Add(0);
        DataAberturaChamado.Add("05/09/2022");

        IdsChamado.Add(1);
        DescricoesChamados.Add("tela azul");
        TituloChamados.Add("Tela Azul");
        EquipamentosChamados.Add(1);
        DataAberturaChamado.Add("06/10/2022");

        ContadorChamados = IdsChamado.Count;
        EquipamentosAdicionados = IdsEquipamento.Count;
        

        comandoPrincipal = MostrarTelaInicial();

        while (true)
        {
            if (Sair() == true)
                break;

            Voltar();

            MostrarMenu();

            RegistroDeEquipamento();

            VisualizarEquipamentosRegistrados();

            if (comandoPrimeiroMenu == "3")
            {
                if (IdsEquipamento.Count == 0)
                {
                    MensagemEhCor("Não tem equipamentos cadastrados!", ConsoleColor.DarkYellow);
                    continue;
                }

                VisualizarEquipamentos();
                Console.WriteLine();
                int IdEquipamento = PegarId("Digite o id do equipamento que você quer editar: ");

                if (IdEquipamento == -1)
                {
                    MensagemEhCor("Id inválido, tente novamente!", ConsoleColor.Red);
                    Console.ResetColor();
                    continue;
                }
                else
                {
                    EditarEquipamento(IdEquipamento);
                    MensagemEhCor("Equipamento editado com sucesso!", ConsoleColor.Green);
                }
            }

            ExcluirEquipamento();

            RegistrarChamado();

            if (comandoSegundoMenu == "2")
            {
                VisualizarChamados();
                Console.ReadLine();
            }

            EditarChamado();

            ExcluirChamado();
        }
    }

    private static void ExcluirChamado()
    {
        if (comandoSegundoMenu == "4")
        {
            VisualizarChamados();
            Console.WriteLine();
            Console.WriteLine("Informe o id do chamado que deseja remover: ");
            int ItemRemovido = int.Parse(Console.ReadLine());
            IdsChamado.RemoveAt(ItemRemovido);
            TituloChamados.RemoveAt(ItemRemovido);
            DataAberturaChamado.RemoveAt(ItemRemovido);
            DescricoesChamados.RemoveAt(ItemRemovido);
            EquipamentosChamados.RemoveAt(ItemRemovido);
        }
    }

    private static void EditarChamado()
    {
        if (comandoSegundoMenu == "3")
        {
            VisualizarChamados();
            Console.WriteLine();
            Console.WriteLine("Informe o id do chamado que deseja editar: ");
            string edicao = Console.ReadLine();
            int idChamado = IdsChamado.IndexOf(int.Parse(edicao));
            Console.WriteLine("Informe o titulo do Chamado: ");
            TituloChamados[idChamado] = Console.ReadLine();
            Console.WriteLine("Informe o id do equipamento: ");
            int NovoID = int.Parse(Console.ReadLine());
            EquipamentosChamados[idChamado] = NovoID;
            Console.WriteLine("Informe a data: ");
            DataAberturaChamado[idChamado] = Console.ReadLine();
        }
    }

    private static void VisualizarChamados()
    {

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("{0,-20} | {1,-20} | {2,-20} | {3,-20}", "ID", "Título do Chamado", "Equipamento", "Data");
        Console.WriteLine("---------------------------------------------------------------------------------------------------------");

        for (int i = 0; i < IdsChamado.Count; i++)
        {
            int idEquipamento = (int)EquipamentosChamados[i];
            int posicao = IdsEquipamento.IndexOf(idEquipamento);
            string nomeEquipamento = (string)NomesEquipamentos[posicao];

            Console.WriteLine("{0,-20} | {1,-20} | {2,-20} | {3,-20}", IdsChamado[i], TituloChamados[i], nomeEquipamento, DataAberturaChamado[i]);
        }
        Console.ResetColor();
        Console.ReadLine();

    }

    private static void RegistrarChamado()
    {
        if (comandoSegundoMenu == "1")
        {
            Console.Clear();
            VisualizarEquipamentos();
            Console.WriteLine();
            Console.WriteLine("Informe o id do equipamento que deseja abrir um chamado: ");
            EquipamentosChamados.Add(int.Parse(Console.ReadLine()));
            Console.WriteLine("Informe o titulo do chamado: ");
            TituloChamados.Add(Console.ReadLine());
            Console.WriteLine("Informe a descrição do chamado: ");
            DescricoesChamados.Add(Console.ReadLine());
            Console.WriteLine("Informe a data de abertura: ");
            DataAberturaChamado.Add(Console.ReadLine());
            IdsChamado.Add(ContadorChamados);
            ContadorChamados++;
        }
    }

    private static void ExcluirEquipamento()
    {
        if (comandoPrimeiroMenu == "4")
        {
            if (IdsEquipamento.Count == 0)
            {
                MensagemEhCor("Não tem equipamentos cadastrados!", ConsoleColor.DarkYellow);
                return;
            }
            VisualizarEquipamentos();

            Console.WriteLine();
            int itemRemovido = PegarId("Digite o id do equipamento que você quer remover: ");
            NomesEquipamentos.RemoveAt(itemRemovido);
            Fabricante.RemoveAt(itemRemovido);
            DataFabricacao.RemoveAt(itemRemovido);
            PrecoEquipamentos.RemoveAt(itemRemovido);
            NumeroSerie.RemoveAt(itemRemovido);
            IdsEquipamento.RemoveAt(itemRemovido);
            MensagemEhCor("Equipamento exluido com sucesso", ConsoleColor.Green);
        }
    }

    private static void MensagemEhCor(string mensagem, ConsoleColor cor)
    {
        Console.ForegroundColor = cor;
        Console.WriteLine(mensagem);
        Console.ResetColor();
        Console.ReadLine();
    }

    private static int PegarId(string mensagem)
    {
        Console.WriteLine(mensagem);
        string edicao = Console.ReadLine();

        int IdEquipamento = IdsEquipamento.IndexOf(int.Parse(edicao));
        return IdEquipamento;
    }

    private static void VisualizarEquipamentosRegistrados()
    {
        Console.WriteLine();
        if (comandoPrimeiroMenu == "2")
        {
            VisualizarEquipamentos();
            Console.ReadLine();
        }
    }

    private static void VisualizarEquipamentos()
    {

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("{0,-10} | {1,-40} | {2,-30}", "ID", "Nome", "Fabricante");
        Console.WriteLine("----------------------------------------------------------------------");
        for (int i = 0; i < IdsEquipamento.Count; i++)
        {
            Console.WriteLine("{0,-10} | {1,-40} | {2,-30}", IdsEquipamento[i], NomesEquipamentos[i], Fabricante[i]);

        }
        Console.ResetColor();
    }

    private static void RegistroDeEquipamento()
    {
        if (comandoPrimeiroMenu == "1")
        {
            Console.Clear();
            Console.WriteLine("Digite o nome do equipamento: ");
            NomesEquipamentos.Add(Console.ReadLine());
            Console.WriteLine("Informe o preço de aquisição: ");
            PrecoEquipamentos.Add(Console.ReadLine());
            Console.WriteLine("Informe o número de série: ");
            NumeroSerie.Add(Console.ReadLine());
            Console.WriteLine("Informe a data de fabricação: ");
            DataFabricacao.Add(Console.ReadLine());
            Console.WriteLine("Informe a fabricante: ");
            Fabricante.Add(Console.ReadLine());
            IdsEquipamento.Add(EquipamentosAdicionados);
            EquipamentosAdicionados++;

        }
    }

    private static void EditarEquipamento(int idEquipamento)
    {
        Console.WriteLine("Digite o nome do equipamento: ");
        NomesEquipamentos[idEquipamento] = Console.ReadLine();
        Console.WriteLine("Informe o preço de aquisição: ");
        PrecoEquipamentos[idEquipamento] = Console.ReadLine();
        Console.WriteLine("Informe o número de série: ");
        Fabricante[idEquipamento] = Console.ReadLine();
        Console.WriteLine("Informe a data de fabricação: ");
        DataFabricacao[idEquipamento] = Console.ReadLine();
        Console.WriteLine("Informe a fabricante: ");
        NumeroSerie[idEquipamento] = Console.ReadLine();
    }

    private static bool Sair()
    {
        if (comandoPrincipal == "s" || comandoPrincipal == "S" || comandoPrimeiroMenu == "s" || comandoPrimeiroMenu == "S" || comandoSegundoMenu == "s" || comandoPrimeiroMenu == "S")
        {
            Console.WriteLine("Saindo...");
            return true;
        }
        return false;
    }

    private static void Voltar()
    {
        if (comandoPrimeiroMenu == "v" || comandoPrimeiroMenu == "V" || comandoSegundoMenu == "v" || comandoSegundoMenu == "V")
        {
            comandoPrincipal = MostrarTelaInicial();
        }
        comandoPrimeiroMenu = "";
    }

    private static void MostrarMenu()
    {
        if (comandoPrincipal == "1")
        {
            Console.Clear();
            Console.WriteLine("Digite 1 para registrar equipamentos");
            Console.WriteLine("Digite 2 para para visualizar todos os equipamentos registrados");
            Console.WriteLine("Digite 3 para editar um equipamento");
            Console.WriteLine("Digite 4 para excluir um equipamento");
            Console.WriteLine();
            Console.WriteLine("Digite V para voltar para tela inicial");
            Console.WriteLine("Digite S para sair");
            comandoPrimeiroMenu = Console.ReadLine();
        }
        else if (comandoPrincipal == "2")
        {
            Console.Clear();
            Console.WriteLine("Digite 1 para registrar chamados de manutenção");
            Console.WriteLine("Digite 2 para visualizar todos os chamados registrados");
            Console.WriteLine("Digite 3 para editar um chamado");
            Console.WriteLine("Digite 4 para excluir um chamado");
            Console.WriteLine();
            Console.WriteLine("Digite V para voltar para tela inicial");
            Console.WriteLine("Digite S para sair");
            comandoSegundoMenu = Console.ReadLine();
        }
    }

    private static string MostrarTelaInicial()
    {
        string comandoPrincipal;
        Console.Clear();
        Console.WriteLine("Digite 1 para controle de equipamentos");
        Console.WriteLine("Digite 2 para controle de chamados");
        Console.WriteLine();
        Console.WriteLine("Digite S para sair");

        comandoPrincipal = Console.ReadLine();
        return comandoPrincipal;
    }



}