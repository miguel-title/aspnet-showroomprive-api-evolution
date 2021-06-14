using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data.Entity;
using AtomicSeller.Models;
using AtomicSeller.ViewModels;
using AtomicSeller.Controllers;
using AtomicSeller.Helpers;
using System.Configuration;
using AtomicSeller.Models.Data;
using AtomicJs.Models.ASTRD;

namespace AtomicSeller
{

    public class DA_REF 
    {
        
        
        public List<Country> GetAllCountries()
        {
            using (ASTRDContext _context = new ASTRDContext())
            {
                return _context.Countries.ToList();
            }
        }

        public void InsertLangToken(string Token)
        {
            using (ASTRDContext _context = new ASTRDContext())
            {
                {
                    try
                    {
                        Lang _Lang = new Lang();
                        _Lang.Token = Token;
                        _context.Langs.Add(_Lang);
                        _context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
        }

        public int DLang_Load()
        {
            var langList = new List<Lang>();

            using (ASTRDContext _context = new ASTRDContext())
            {
                langList = _context.Langs.ToList();

                foreach (Lang LangElement in langList)
                {
                    try
                    {
                        Local.D_Lang.Add(LangElement.Token.ToUpper(),
                            new Local.InternationalMessage3(
                                LangElement.Token,
                                LangElement.EnUs,
                                LangElement.FrFr,
                                LangElement.DeDe,
                                LangElement.EsEs,
                                LangElement.ItIt,
                                LangElement.ZhChs,
                                LangElement.NlNl,
                                LangElement.ZhTw,
                                LangElement.ElGr,
                                LangElement.JaJp,
                                LangElement.PtPt,
                                LangElement.RuRu,
                                LangElement.HiIn,
                                LangElement.PlPl,
                                LangElement.IdId,
                                LangElement.ArEg
                                )
                            );
                    }
                    catch { }
                }
            }

            return langList.Count;
        }


        
    }
}