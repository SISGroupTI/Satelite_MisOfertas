// File:    Track.cs
// Author:  Ian Cardenas
// Created: miércoles, 6 de septiembre de 2017 13:43:07
// Purpose: Definition of Class Track

using System;

public class Track
{
   public long idTrack;
   public DateTime fechaAccion;
   public java.lang.String accion;
   
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
               oldConsumidor.RemoveTrack(this);
            }
            if (value != null)
            {
               this.consumidor = value;
               this.consumidor.AddTrack(this);
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
               oldOferta.RemoveTrack(this);
            }
            if (value != null)
            {
               this.oferta = value;
               this.oferta.AddTrack(this);
            }
         }
      }
   }
   public Rubro rubro;
   
   /// <summary>
   /// Property for Rubro
   /// </summary>
   /// <pdGenerated>Default opposite class property</pdGenerated>
   public Rubro Rubro
   {
      get
      {
         return rubro;
      }
      set
      {
         if (this.rubro == null || !this.rubro.Equals(value))
         {
            if (this.rubro != null)
            {
               Rubro oldRubro = this.rubro;
               this.rubro = null;
               oldRubro.RemoveTrack(this);
            }
            if (value != null)
            {
               this.rubro = value;
               this.rubro.AddTrack(this);
            }
         }
      }
   }

}