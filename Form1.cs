namespace JogoDaMemoria
{

    public partial class Form1 : Form
    {
        //lista com pares e um coringa
        private List<string> valores = new List<string>
        {
            "A","A","B","B","C","C","D","D","E","E","F","F","G","G","H","H"
        };


        // 2 botões de clique
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
            // percorrer os botões que estão dentro do tableLayout
            foreach(Control controle in tableLayoutPanel2.Controls)
            {
                // se o componente é um botão
                if (controle is Button botao)
                {
                    // gera um número aleatorio até 16
                    int indiceAleatorio = random.Next(valores.Count);
                    //determina o texto do botão
                    botao.Text = valores[indiceAleatorio];
                    // definir cor do texto
                    botao.ForeColor = botao.BackColor = Color.Black;
                    // remover o valor já usado
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
            // reconhecer o botão clicado como o enviado;
            Button botaoClicado = sender as Button;

            // evitar o clique nos mesmos botões duas vezes
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
