//Tony
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;
using System.Configuration;
using System.Security.Cryptography;
using System.Runtime.Serialization;
using System.ServiceModel;
using MySql.Data.MySqlClient;


namespace WcfGestionStock.ClassGestionStock
{    
    [DataContract]
    public class ClsUtilisateur
    {        
        private int id;
        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string login;
        [DataMember]
        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        private string motdepasse;
        [DataMember]
        public string MotDePasse
        {
            get { return motdepasse; }
            set { motdepasse = value; }
        }

        private string nom;
        [DataMember]
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        private string prenom;
        [DataMember]
        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }

        private string mail;
        [DataMember]
        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }

        private int id_statut;
        [DataMember]
        public int Id_Statut
        {
            get { return id_statut; }
            set { id_statut = value; }
        }

        private string societe;
        [DataMember]
        public string Societe
        {
            get { return societe; }
            set { societe = value; }
        }

        private string service;
        [DataMember]
        public string Service
        {
            get { return service; }
            set { service = value; }
        }

        
        public ClsUtilisateur() { }

    }
}
