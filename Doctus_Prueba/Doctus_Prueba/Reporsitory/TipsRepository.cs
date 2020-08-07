﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Doctus_Prueba.Models;
using SQLite;

namespace Doctus_Prueba.Reporsitory
{
    public class TipsRepository
    {
        private SQLiteConnection con;
        private static TipsRepository tipsR;
        public string response;
        public static TipsRepository TipsR { get { if (tipsR == null) throw new Exception("Error al instanciar"); return tipsR; } }
        
        public static void Validar(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException();

            if (TipsR != null)
                tipsR.con.Close();
            tipsR = new TipsRepository(fileName);
        }

        private TipsRepository(string path)
        {
            this.con = new SQLiteConnection(path);
            this.con.CreateTable<Tip>();
        }

        public IEnumerable<Tip> GetAllTips()
        {
            try
            {
                return this.con.Table<Tip>();
            }
            catch (Exception ex)
            {
                this.response = ex.Message;
            }
            return Enumerable.Empty<Tip>();
        }

        public int AddTip(string _titulo, string _desc)
        {
            int rpta = 0;
            try
            {
                rpta = con.Insert(new Tip() { Titulo = _titulo, Descripcion = _desc, FechaCreacion = DateTime.Now });
                this.response = string.Format($"Filas Agregadas --> {rpta}");
            }
            catch (Exception ex)
            {
                this.response = ex.Message;
            }
            return rpta;
        }

        
    }
}