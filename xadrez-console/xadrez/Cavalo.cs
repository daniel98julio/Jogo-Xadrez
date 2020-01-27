using tabuleiro;

namespace xadrez {
    class Cavalo:Peca {

        public Cavalo(Tabuleiro tab, Cor cor) : base(tab, cor) {
        }

        public override string ToString() {
            return "C";
        }

        private bool podeMover(Posicao pos) {
            Peca p = tab.peca(pos);
            return p == null || p.cor != cor;
        }
        public override bool[,] movimentosPossiveis() {
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(0, 0);

            //1 PARA NORTE E 2 PARA OESTE
            pos.definirValores(posicao.linha - 1, posicao.coluna - 2);
            if(tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }

            //2 PARA NORTE E 1 PARA OESTE
            pos.definirValores(posicao.linha - 2, posicao.coluna - 1);
            if(tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }

            //2 NORTE E 1 LESTE
            pos.definirValores(posicao.linha - 2, posicao.coluna + 1);
            if(tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }

            //1 NORTE E 2 LESTE
            pos.definirValores(posicao.linha - 1, posicao.coluna + 2);
            if(tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }

            //1 SUL E 2 LESTE
            pos.definirValores(posicao.linha + 1, posicao.coluna + 2);
            if(tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }

            //2 SUL E 1 OESTE
            pos.definirValores(posicao.linha + 2, posicao.coluna - 1);
            if(tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }

            //1 SUL E 2 OESTE
            pos.definirValores(posicao.linha + 1, posicao.coluna - 2);
            if(tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }

            return mat;
        }
    }
}
