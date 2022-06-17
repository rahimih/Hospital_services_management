using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAcessClass;
using BussinessClass;

namespace  DLibraryUtils
{
   public  class DLUtils
    {
       


        public BussinessClass.BussinessClass.userchecking usercheckingobj;
        public BussinessClass.BussinessClass.EventsLog EventsLogobj;
        public BussinessClass.BussinessClass.persontbl persontblobj;
        public BussinessClass.BussinessClass.radio_recipe radio_recipeobj;
        public BussinessClass.BussinessClass.radio_Dentistrecipe radio_Dentistrecipeobj;
        public BussinessClass.BussinessClass.SONO_recipe Sono_recipeobj;
        public BussinessClass.BussinessClass.Physio_recipe Physio_recipeobj;
        public BussinessClass.BussinessClass.tariff tariffobj;
        public BussinessClass.BussinessClass.EMR_recipe EMR_recipeobj;
        public BussinessClass.BussinessClass.StoreTa StoreTaobj;
        public BussinessClass.BussinessClass.StorePh StorePhobj;
        public BussinessClass.BussinessClass.psychology_Recipe psychology_Recipeobj;
        public BussinessClass.BussinessClass.Dr_Procedures_Recipe Dr_Procedures_Recipeobj;
        public BussinessClass.BussinessClass.Surgery Surgeryobj;
        public BussinessClass.BussinessClass.Surgerytemp1 Surgerytemp1obj;
        public BussinessClass.BussinessClass.Surgerytemp2 Surgerytemp2obj;
        public BussinessClass.BussinessClass.P_personel P_personelobj;
        public BussinessClass.BussinessClass.P_personel_temp P_personeltempobj;
      




        public DLUtils()
        {
            usercheckingobj = new BussinessClass.BussinessClass.userchecking();
            EventsLogobj = new BussinessClass.BussinessClass.EventsLog();
            persontblobj = new BussinessClass.BussinessClass.persontbl();
            radio_recipeobj = new BussinessClass.BussinessClass.radio_recipe();
            radio_Dentistrecipeobj = new BussinessClass.BussinessClass.radio_Dentistrecipe();
            Sono_recipeobj = new BussinessClass.BussinessClass.SONO_recipe();
            Physio_recipeobj = new BussinessClass.BussinessClass.Physio_recipe();
            tariffobj = new BussinessClass.BussinessClass.tariff();
            EMR_recipeobj = new BussinessClass.BussinessClass.EMR_recipe();
            StoreTaobj = new BussinessClass.BussinessClass.StoreTa();
            StorePhobj = new BussinessClass.BussinessClass.StorePh();
            psychology_Recipeobj = new BussinessClass.BussinessClass.psychology_Recipe();
            Dr_Procedures_Recipeobj = new BussinessClass.BussinessClass.Dr_Procedures_Recipe();
            Surgeryobj = new BussinessClass.BussinessClass.Surgery();
            Surgerytemp1obj = new BussinessClass.BussinessClass.Surgerytemp1();
            Surgerytemp2obj = new BussinessClass.BussinessClass.Surgerytemp2();
            P_personelobj = new BussinessClass.BussinessClass.P_personel();
            P_personeltempobj = new BussinessClass.BussinessClass.P_personel_temp();

               
          

        }
    }
}
