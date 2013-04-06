using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
namespace DEV_PeopleNET358
{

    [Persistent(@"PeopleNET.Funcao")]
    public class PeopleNET_Funcao : XPLiteObject
    {
        int fin_IDFuncao;
        [Key(true)]
        public int in_IDFuncao
        {
            get { return fin_IDFuncao; }
            set { SetPropertyValue<int>("in_IDFuncao", ref fin_IDFuncao, value); }
        }
        string fvc_CodFuncao;
        [Size(20)]
        public string vc_CodFuncao
        {
            get { return fvc_CodFuncao; }
            set { SetPropertyValue<string>("vc_CodFuncao", ref fvc_CodFuncao, value); }
        }
        string fvc_NomeFuncao;
        public string vc_NomeFuncao
        {
            get { return fvc_NomeFuncao; }
            set { SetPropertyValue<string>("vc_NomeFuncao", ref fvc_NomeFuncao, value); }
        }
        bool fbt_FlagSituacao;
        public bool bt_FlagSituacao
        {
            get { return fbt_FlagSituacao; }
            set { SetPropertyValue<bool>("bt_FlagSituacao", ref fbt_FlagSituacao, value); }
        }
        int fin_IDEmpresa;
        public int in_IDEmpresa
        {
            get { return fin_IDEmpresa; }
            set { SetPropertyValue<int>("in_IDEmpresa", ref fin_IDEmpresa, value); }
        }
        string fvc_ReqFuncao;
        [Size(SizeAttribute.Unlimited)]
        public string vc_ReqFuncao
        {
            get { return fvc_ReqFuncao; }
            set { SetPropertyValue<string>("vc_ReqFuncao", ref fvc_ReqFuncao, value); }
        }
        int fin_IDCBO;
        public int in_IDCBO
        {
            get { return fin_IDCBO; }
            set { SetPropertyValue<int>("in_IDCBO", ref fin_IDCBO, value); }
        }
        DateTime fsd_DataInclusao;
        public DateTime sd_DataInclusao
        {
            get { return fsd_DataInclusao; }
            set { SetPropertyValue<DateTime>("sd_DataInclusao", ref fsd_DataInclusao, value); }
        }
        public PeopleNET_Funcao(Session session) : base(session) { }
        public PeopleNET_Funcao() : base(Session.DefaultSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }


}
