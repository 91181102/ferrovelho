using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleCompraVenda.Dados
{
    public class Tempo
    {
        private Timer timer_relogio = new Timer();

        /// <summary>
        /// Obtém ou define a hora em que será executado a tarefa.
        /// </summary>
        private DateTime dtHrInicio = DateTime.Now;

        /// <summary>
        /// Obtém ou define se a tarefa foi executada.
        /// </summary>
        private bool isExecuted = true;

        /// <summary>
        /// Obtém ou define a data do dia.
        /// </summary>
        public string data { get; private set; }

        /// <summary>
        /// Obtém ou define a hora atual.
        /// </summary>
        public string hora { get; private set; }
        public Label lbProxData { get; private set; }
        public Label lbStatus { get; private set; }
        private Label labHora { get; set; }

        /// <summary>
        /// Obtém ou define se o objeto label deverá ser atualizado.
        /// </summary>
        private bool refreshLabel = false;

        /// <summary>
        /// Obtém ou define o label que exibirá a data.
        /// </summary>
        private ToolStripStatusLabel lbData { get; set; }

        /// <summary>
        /// Obtém ou define o label que exibirá a hora.
        /// </summary>
        private ToolStripStatusLabel lbHora { get; set; }

        /// <summary>
        /// Define um objeto delegate.
        /// </summary>
        public delegate void PassControl();

        /// <summary>
        /// Obtém ou define o método a ser executado.
        /// </summary>
        private PassControl ExecOnTimer { get; set; }

        /// <summary>
        /// Cria uma nova instância de tempo.
        /// </summary>
        public Tempo() {
            this.timerConfig();
        }

        public Tempo(PassControl ExecOnTimer) {
            this.timerConfig();
            this.ExecOnTimer = ExecOnTimer;
        }

        /// <summary>
        /// Cria uma nova instância de tempo.
        /// </summary>
        /// <param name="lbData">Label para exibir a data.</param>
        /// <param name="lbHora">Label para exibir a hora.</param>
        public Tempo(ToolStripStatusLabel lbData, ToolStripStatusLabel lbHora) {
            this.lbData = lbData;
            this.lbHora = lbHora;
            this.refreshLabel = true;
            this.timerConfig();
        }

        /// <summary>
        /// Cria uma nova instância de Tempo.
        /// </summary>
        /// <param name="lbHora"></param>
        public Tempo(Label labHora) {
            this.labHora = labHora;
            this.refreshLabel = true;
            this.timerConfig();
        }

        public void setLabels(ToolStripStatusLabel lbData, ToolStripStatusLabel lbHora, Label lbProxData, Label lbStatus) {
            this.lbData = lbData;
            this.lbHora = lbHora;
            this.lbProxData = lbProxData;
            this.lbStatus = lbStatus;
            this.refreshLabel = true;
        }

        /// <summary>
        /// Método para configurar o intervalo do timer em 1 segundo e iniciá-lo.
        /// </summary>
        private void timerConfig() {
            timer_relogio.Interval = 1000;
            timer_relogio.Start();
            this.timer_relogio.Tick += new EventHandler(this.timer_relogio_Tick);
        }

        /// <summary>
        /// Método para rodar o cronômetro do relógio da barra de status.
        /// </summary>
        /// <param name="sender">Objeto Timer</param>
        /// <param name="e">Intervalo de tempo.</param>
        private void timer_relogio_Tick(object sender, EventArgs e) {
            this.data = DateTime.Now.ToString("dd/MM/yyyy");
            this.hora = DateTime.Now.ToString("HH:mm:ss");

            if (refreshLabel) {
                if (this.lbData != null)
                    this.lbData.Text = this.data;
                if (this.lbHora != null)
                    this.lbHora.Text = this.hora;
                if (labHora != null)
                    this.labHora.Text = this.hora; }

            if (dtHrInicio < DateTime.Now && !isExecuted) {
                this.lbStatus.Text = "Executando";
                this.lbStatus.ForeColor = System.Drawing.Color.Blue;
                this.isExecuted = true;
                this.ExecOnTimer();
                this.lbStatus.Text = "Ativado";
                this.lbStatus.ForeColor = System.Drawing.Color.Green; }
        }

        /// <summary>
        /// Define a data e hora para inicio da tarefa.
        /// </summary>
        /// <param name="dtHrInicio">Dia e Hora.</param>
        public void setDtHrInicio(DateTime dtHrInicio)
        {
            this.dtHrInicio = dtHrInicio;
            this.isExecuted = false;
            this.lbProxData.Text = dtHrInicio.ToString("dd/MM/yyyy HH:mm:ss");
        }

        /// <summary>
        /// Ativa o timer do processo.
        /// </summary>
        public void ativar()
        {
            this.timer_relogio.Start();
        }

        /// <summary>
        /// Desativa o timer do processo.
        /// </summary>
        public void desativar()
        {
            this.timer_relogio.Stop();
        }
    }
}
