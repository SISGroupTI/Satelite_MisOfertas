// File:    Rubro.cs
// Author:  Ian Cardenas
// Created: miércoles, 6 de septiembre de 2017 13:43:07
// Purpose: Definition of Class Rubro

using System;

public class Rubro
{
   protected void Finalize()
   {
      throw new NotImplementedException();
   }
   
   public long GetIdRubro()
   {
      throw new NotImplementedException();
   }
   
   public void SetIdRubro(long newIdRubro)
   {
      throw new NotImplementedException();
   }
   
   public java.lang.String GetDescripcionRubro()
   {
      throw new NotImplementedException();
   }
   
   public void SetDescripcionRubro(java.lang.String newDescripcionRubro)
   {
      throw new NotImplementedException();
   }
   
   public Rubro()
   {
      throw new NotImplementedException();
   }
   
   public long idRubro;
   public java.lang.String descripcionRubro;
   
   public System.Collections.ArrayList track;
   
   /// <summary>
   /// Property for collection of Track
   /// </summary>
   /// <pdGenerated>Default opposite class collection property</pdGenerated>
   public System.Collections.ArrayList Track
   {
      get
      {
         if (track == null)
            track = new System.Collections.ArrayList();
         return track;
      }
      set
      {
         RemoveAllTrack();
         if (value != null)
         {
            foreach (Track oTrack in value)
               AddTrack(oTrack);
         }
      }
   }
   
   /// <summary>
   /// Add a new Track in the collection
   /// </summary>
   /// <pdGenerated>Default Add</pdGenerated>
   public void AddTrack(Track newTrack)
   {
      if (newTrack == null)
         return;
      if (this.track == null)
         this.track = new System.Collections.ArrayList();
      if (!this.track.Contains(newTrack))
      {
         this.track.Add(newTrack);
         newTrack.Rubro = this;
      }
   }
   
   /// <summary>
   /// Remove an existing Track from the collection
   /// </summary>
   /// <pdGenerated>Default Remove</pdGenerated>
   public void RemoveTrack(Track oldTrack)
   {
      if (oldTrack == null)
         return;
      if (this.track != null)
         if (this.track.Contains(oldTrack))
         {
            this.track.Remove(oldTrack);
            oldTrack.Rubro = null;
         }
   }
   
   /// <summary>
   /// Remove all instances of Track from the collection
   /// </summary>
   /// <pdGenerated>Default removeAll</pdGenerated>
   public void RemoveAllTrack()
   {
      if (track != null)
      {
         System.Collections.ArrayList tmpTrack = new System.Collections.ArrayList();
         foreach (Track oldTrack in track)
            tmpTrack.Add(oldTrack);
         track.Clear();
         foreach (Track oldTrack in tmpTrack)
            oldTrack.Rubro = null;
         tmpTrack.Clear();
      }
   }
   public System.Collections.ArrayList oferta;
   
   /// <summary>
   /// Property for collection of Oferta
   /// </summary>
   /// <pdGenerated>Default opposite class collection property</pdGenerated>
   public System.Collections.ArrayList Oferta
   {
      get
      {
         if (oferta == null)
            oferta = new System.Collections.ArrayList();
         return oferta;
      }
      set
      {
         RemoveAllOferta();
         if (value != null)
         {
            foreach (Oferta oOferta in value)
               AddOferta(oOferta);
         }
      }
   }
   
   /// <summary>
   /// Add a new Oferta in the collection
   /// </summary>
   /// <pdGenerated>Default Add</pdGenerated>
   public void AddOferta(Oferta newOferta)
   {
      if (newOferta == null)
         return;
      if (this.oferta == null)
         this.oferta = new System.Collections.ArrayList();
      if (!this.oferta.Contains(newOferta))
      {
         this.oferta.Add(newOferta);
         newOferta.Rubro = this;
      }
   }
   
   /// <summary>
   /// Remove an existing Oferta from the collection
   /// </summary>
   /// <pdGenerated>Default Remove</pdGenerated>
   public void RemoveOferta(Oferta oldOferta)
   {
      if (oldOferta == null)
         return;
      if (this.oferta != null)
         if (this.oferta.Contains(oldOferta))
         {
            this.oferta.Remove(oldOferta);
            oldOferta.Rubro = null;
         }
   }
   
   /// <summary>
   /// Remove all instances of Oferta from the collection
   /// </summary>
   /// <pdGenerated>Default removeAll</pdGenerated>
   public void RemoveAllOferta()
   {
      if (oferta != null)
      {
         System.Collections.ArrayList tmpOferta = new System.Collections.ArrayList();
         foreach (Oferta oldOferta in oferta)
            tmpOferta.Add(oldOferta);
         oferta.Clear();
         foreach (Oferta oldOferta in tmpOferta)
            oldOferta.Rubro = null;
         tmpOferta.Clear();
      }
   }
   public System.Collections.ArrayList certificadoRubro;
   
   /// <summary>
   /// Property for collection of CertificadoRubro
   /// </summary>
   /// <pdGenerated>Default opposite class collection property</pdGenerated>
   public System.Collections.ArrayList CertificadoRubro
   {
      get
      {
         if (certificadoRubro == null)
            certificadoRubro = new System.Collections.ArrayList();
         return certificadoRubro;
      }
      set
      {
         RemoveAllCertificadoRubro();
         if (value != null)
         {
            foreach (CertificadoRubro oCertificadoRubro in value)
               AddCertificadoRubro(oCertificadoRubro);
         }
      }
   }
   
   /// <summary>
   /// Add a new CertificadoRubro in the collection
   /// </summary>
   /// <pdGenerated>Default Add</pdGenerated>
   public void AddCertificadoRubro(CertificadoRubro newCertificadoRubro)
   {
      if (newCertificadoRubro == null)
         return;
      if (this.certificadoRubro == null)
         this.certificadoRubro = new System.Collections.ArrayList();
      if (!this.certificadoRubro.Contains(newCertificadoRubro))
      {
         this.certificadoRubro.Add(newCertificadoRubro);
         newCertificadoRubro.Rubro = this;
      }
   }
   
   /// <summary>
   /// Remove an existing CertificadoRubro from the collection
   /// </summary>
   /// <pdGenerated>Default Remove</pdGenerated>
   public void RemoveCertificadoRubro(CertificadoRubro oldCertificadoRubro)
   {
      if (oldCertificadoRubro == null)
         return;
      if (this.certificadoRubro != null)
         if (this.certificadoRubro.Contains(oldCertificadoRubro))
         {
            this.certificadoRubro.Remove(oldCertificadoRubro);
            oldCertificadoRubro.Rubro = null;
         }
   }
   
   /// <summary>
   /// Remove all instances of CertificadoRubro from the collection
   /// </summary>
   /// <pdGenerated>Default removeAll</pdGenerated>
   public void RemoveAllCertificadoRubro()
   {
      if (certificadoRubro != null)
      {
         System.Collections.ArrayList tmpCertificadoRubro = new System.Collections.ArrayList();
         foreach (CertificadoRubro oldCertificadoRubro in certificadoRubro)
            tmpCertificadoRubro.Add(oldCertificadoRubro);
         certificadoRubro.Clear();
         foreach (CertificadoRubro oldCertificadoRubro in tmpCertificadoRubro)
            oldCertificadoRubro.Rubro = null;
         tmpCertificadoRubro.Clear();
      }
   }

}