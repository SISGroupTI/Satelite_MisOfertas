// File:    ImgOferta.cs
// Author:  Ian Cardenas
// Created: miércoles, 6 de septiembre de 2017 13:43:07
// Purpose: Definition of Class ImgOferta

using System;

public class ImgOferta
{
   protected void Finalize()
   {
      throw new NotImplementedException();
   }
   
   public java.lang.String GetImagen()
   {
      throw new NotImplementedException();
   }
   
   public void SetImagen(java.lang.String newImagen)
   {
      throw new NotImplementedException();
   }
   
   public short GetIsPrincipal()
   {
      throw new NotImplementedException();
   }
   
   public void SetIsPrincipal(short newIsPrincipal)
   {
      throw new NotImplementedException();
   }
   
   public ImgOferta()
   {
      throw new NotImplementedException();
   }
   
   public java.lang.String imagen;
   public short isPrincipal;
   
   public Oferta oferta;
   
   /// <summary>
   /// Property for Oferta
   /// </summary>
   /// <pdGenerated>Default opposite class property</pdGenerated>
   public Oferta Oferta
   {
      get
      {
         return oferta;
      }
      set
      {
         if (this.oferta == null || !this.oferta.Equals(value))
         {
            if (this.oferta != null)
            {
               Oferta oldOferta = this.oferta;
               this.oferta = null;
               oldOferta.RemoveImgOferta(this);
            }
            if (value != null)
            {
               this.oferta = value;
               this.oferta.AddImgOferta(this);
            }
         }
      }
   }

}