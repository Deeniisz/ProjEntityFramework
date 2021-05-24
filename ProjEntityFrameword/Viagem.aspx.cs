using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjEntityFrameword
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack) 
            {
                CarregarDadosPagina();
            }
        }
    }
    protected void btnCadastrar_Click(object sender, EventArgs e)
    {
        string descricaoViagem = txtDescricao.Text;
        DateTime data = Convert.ToDateTime(txtData.Text);
        TB_VIAGEM v = new TB_VIAGEM() { descricao = descricaoViagem, data = data };
        ViagemDBEntities contextViagem = new ViagemDBEntities();
        string valor = RequestNotification.QueryString["idItem"];

        if (String.IsNullOrEmpty(Valor))
        {
            contextViagem.TB_VIAGEM.Add(v);
            lblmsg.Text = "Registro Alterado!";
        }
        contextViagem.SaveChanges();
    }

    private void Clear()
    {
        txtdata.Text = "";
        txtDescricao.Text = "";
        txtDescricao.Focus();
    }

    private void CarregarDadosPagina()
    {
        string valor = Request.QueryString["idItem"];
        int idItem = 0;
        TB_VIAGEM viagem = new TB_VIAGEM();
        ViagemDBEntities contextViagem = new ViagemDBEntities();

        if (!String.IsNullOrEmpty(valor))
        {
            idItem = Convert.ToInt32(valor);
            viagem = contextViagem.TB_VIAGEM.First(c => c.id == idItem);

            txtDescricao.Text = viagem.descricao;
            txtdata.Text = viagem.data.ToString();
        }
    }
}