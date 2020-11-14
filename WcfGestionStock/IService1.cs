using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using WcfGestionStock.ClassGestionStock;
namespace WcfGestionStock
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IService1
    {
        #region Utilisateur
        [OperationContract]
        bool Loguer(string LoginUtilisateur, string MotDePasse);

        [OperationContract]
        List<ClsUtilisateur> LireTableUtilisateurSql(string _RequeteSql);

        [OperationContract]
        void AjoutSupModifUtilisateurSql(string _RequeteSql);
        #endregion


        #region Produit
        [OperationContract]
        List<ClsStockProduit> LireStockProduitSql(string _RequeteSql);

        [OperationContract]
        List<ClsStockProduit> SommeProduitSql(string _RequeteSql);

        [OperationContract]
        List<ClsStockProduit> LireCategorieSql(string _RequeteSql);

        [OperationContract]
        void AjoutSupModifProduitSql(string _RequeteSql);
        #endregion


        #region Panier
        [OperationContract]
        List<ClsPanier> LireTablePanierSql(string _RequeteSql);

        [OperationContract]
        List<ClsPanier> SommePanierSql(string _RequeteSql);

        [OperationContract]
        void AjoutSupModifPanierSql(string _RequeteSql);
        #endregion


        #region Commande client
        [OperationContract]
        List<ClsCmdClient> LireCmdClientSql(string _RequeteSql);

        [OperationContract]
        List<ClsCmdClient> SommeCmdClientSql(string _RequeteSql);
        [OperationContract]
        void AjoutSupModifCmdClientSql(string _RequeteSql);
        #endregion


        #region Fournisseur
        [OperationContract]
        List<ClsFournisseur> LireFournisseurSql(string _RequeteSql);
        [OperationContract]
        void AjoutSupModifFournisseurSql(string _RequeteSql);
        #endregion


        #region Commande Fournisseur
        [OperationContract]
        List<ClsCmdFournisseur> LireCmdFournisseurSql(string _RequeteSql);
        [OperationContract]
        void AjoutSupModifCmdFournisseurSql(string _RequeteSql);
        [OperationContract]
        List<ClsCmdFournisseur> SommeCmdFournisseurSql(string _RequeteSql);
        #endregion
    }


}
