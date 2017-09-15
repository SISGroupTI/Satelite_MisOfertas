// File:    HistorialCorreo.cs
// Author:  Ian Cardenas
// Created: miércoles, 6 de septiembre de 2017 13:43:07
// Purpose: Definition of Class HistorialCorreo

using System;

public class HistorialCorreo
{
   protected void Finalize()
   {
      throw new NotImplementedException();
   }
   
   public long GetIdHistorialCorreo()
   {
      throw new NotImplementedException();
   }
   
   public void SetIdHistorialCorreo(long newIdHistorialCorreo)
   {
      throw new NotImplementedException();
   }
   
   public DateTime get_fechaEnvio()
   {
      throw new NotImplementedException();
   }
   
   public void SetFechaEnvio(DateTime newFechaEnvio)
   {
      throw new NotImplementedException();
   }
   
   public HistorialCorreo()
   {
      throw new NotImplementedException();
   }
   
   public long idHistorialCorreo;
   public DateTime fechaEnvio;
   
   public Consumidor consumidor;
   
   /// <summary>
   /// Property for Consumidor
   /// </summary>
   /// <pdGenerated>Default opposite class property</pdGenerated>
   public Consumidor Consumidor
   {
      get
      {
         return consumidor;
      }
      set
      {
         if (this.consumidor == null || !this.consumidor.Equals(value))
         {
            if (this.consumidor != null)
            {
               Consumidor oldConsumidor = this.consumidor;
               this.consumidor = null;
               oldConsumidor.RemoveHistorialCorreo(this);
            }
            if (value != null)
            {
               this.consumidor = value;
               this.consumidor.AddHistorialCorreo(this);
            }
         }
      }
   }
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
               oldOferta.RemoveHistorialCorreo(this);
            }
            if (value != null)
            {
               this.oferta = value;
               this.oferta.AddHistorialCorreo(this);
            }
         }
      }
   }

}