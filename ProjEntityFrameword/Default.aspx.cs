using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjEntityFrameword
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CarregarLista();

        }

        private void CarregarLista()
        {
            ViagemDBEntities context = new ViagemDBEntities();
            List<TB_VIAGEM> lstViagem = context.TB_VIAGEM.ToList<TB_VIAGEM>();

            GVViagem.DataSource = lstViagem;
            GVViagem.DataBind();
        }

        protected void GVViagem_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idItem = Convert.ToInt32(e.CommandArgument.ToString());
            ViagemDBEntities contextViagem = new ViagemDBEntities();
            TB_VIAGEM viagem = new TB_VIAGEM();

            viagem = contextViagem.TB_VIAGEM.First(c => c.id == idItem);

            if(e.CommandName == "ALTERAR")
            {
                Response.Redirect("Viagem.aspx?idItem=" + idItem);
            }
            else if(e.CommandName == "EXCLUIR")
            {
                contextViagem.TB_VIAGEM.Remove(viagem);
                contextViagem.SaveChanges();
                string msg = "Viagem excluida com sucesso !";
                string titulo = "Informação";
                CarregarLista();
                DisplayAlert(titulo, msg, this);
            }
        }
        public void DisplayAlert(string titulo, string mensagem, System.Web.UI.Page page)
        {
            h1.innerText = titulo;
            lblMsgPopup.InnerText = mensagem;
            ClienteScript.RegisterStartupScript(typeof(Page), Guid.NewGuid().ToString(), "MostrarPopupMensagem();", true);
        }
    }
}