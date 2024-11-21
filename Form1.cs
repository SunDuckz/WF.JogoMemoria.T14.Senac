namespace JogoDaMemoria
{

    public partial class Form1 : Form
    {
        //lista com pares e um coringa
        private List<string> valores = new List<string>
        {
            "A","A","B","B","C","C","D","D","E","E","F","F","G","G","H","H"
        };


        // 2 bot�es de clique
        private Button primeiroClique, segundoClique;

        // gerador de numero randomico
        private Random random = new Random();

        public Form1()
        {
            InitializeComponent();
            DistribuirLetras();
        }

        private void DistribuirLetras()
        {
            // percorrer os bot�es que est�o dentro do tableLayout
            foreach(Control controle in tableLayoutPanel2.Controls)
            {
                // se o componente � um bot�o
                if (controle is Button botao)
                {
                    // gera um n�mero aleatorio at� 16
                    int indiceAleatorio = random.Next(valores.Count);
                    //determina o texto do bot�o
                    botao.Text = valores[indiceAleatorio];
                    // definir cor do texto
                    botao.ForeColor = botao.BackColor = Color.Black;
                    // remover o valor j� usado
                    valores.RemoveAt(indiceAleatorio);
                    // adicionar o evento de clique 
                    botao.Click += Botao_click;
                }
            }
        }

        private void Botao_click(object? sender, EventArgs e)
        {
            // verificar se ja cliquei em dois botoes
            if(primeiroClique != null && segundoClique != null)
            {
                return;
            }
            // reconhecer o bot�o clicado como o enviado;
            Button botaoClicado = sender as Button;

            // evitar o clique nos mesmos bot�es duas vezes
            if(botaoClicado == null || botaoClicado.ForeColor == Color.White)
            {
                return;
            }
            // mudar a cor da letra pra branco -> visualizar a letra
            botaoClicado.ForeColor = Color.White;

            if(primeiroClique == null)
            {
                primeiroClique = botaoClicado;
                return;
            }

            segundoClique = botaoClicado;

            if(primeiroClique.Text == segundoClique.Text && primeiroClique != segundoClique)
            {
                primeiroClique = null;
                segundoClique = null;
                verificarVitoria();
            }
            else
            {
                Thread.Sleep(1000);
                primeiroClique.ForeColor = primeiroClique.BackColor;
                segundoClique.ForeColor = segundoClique.BackColor;
                primeiroClique = null;
                segundoClique = null;
            }
            // fim Botao_click

        }

        private void verificarVitoria()
        {
           
        }
    }
}
