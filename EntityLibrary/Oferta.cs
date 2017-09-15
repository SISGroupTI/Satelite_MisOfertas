// File:    Oferta.cs
// Author:  Ian Cardenas
// Created: miércoles, 6 de septiembre de 2017 13:43:07
// Purpose: Definition of Class Oferta

using System;

public class Oferta
{
   protected void Finalize()
   {
      throw new NotImplementedException();
   }
   
   public long GetIdOferta()
   {
      throw new NotImplementedException();
   }
   
   public void SetIdOferta(long newIdOferta)
   {
      throw new NotImplementedException();
   }
   
   public int GetCodigoOferta()
   {
      throw new NotImplementedException();
   }
   
   public void SetCodigoOferta(int newCodigoOferta)
   {
      throw new NotImplementedException();
   }
   
   public DateTime get_fechaCreacion()
   {
      throw new NotImplementedException();
   }
   
   public void SetFechaCreacion(DateTime newFechaCreacion)
   {
      throw new NotImplementedException();
   }
   
   public DateTime get_fechaInicio()
   {
      throw new NotImplementedException();
   }
   
   public void SetFechaInicio(DateTime newFechaInicio)
   {
      throw new NotImplementedException();
   }
   
   public DateTime get_fechaFinalzacion()
   {
      throw new NotImplementedException();
   }
   
   public void SetFechaFinalzacion(DateTime newFechaFinalzacion)
   {
      throw new NotImplementedException();
   }
   
   public int GetPrecio()
   {
      throw new NotImplementedException();
   }
   
   public void SetPrecio(int newPrecio)
   {
      throw new NotImplementedException();
   }
   
   public short GetIsVisible()
   {
      throw new NotImplementedException();
   }
   
   public void SetIsVisible(short newIsVisible)
   {
      throw new NotImplementedException();
   }
   
   public java.lang.String GetTituloOferta()
   {
      throw new NotImplementedException();
   }
   
   public void SetTituloOferta(java.lang.String newTituloOferta)
   {
      throw new NotImplementedException();
   }
   
   public java.lang.String GetDescripcionOferta()
   {
      throw new NotImplementedException();
   }
   
   public void SetDescripcionOferta(java.lang.String newDescripcionOferta)
   {
      throw new NotImplementedException();
   }
   
   public java.lang.String GetCondiciones()
   {
      throw new NotImplementedException();
   }
   
   public void SetCondiciones(java.lang.String newCondiciones)
   {
      throw new NotImplementedException();
   }
   
   public short GetIsDisponible()
   {
      throw new NotImplementedException();
   }
   
   public void SetIsDisponible(short newIsDisponible)
   {
      throw new NotImplementedException();
   }
   
   public DateTime get_fechaModificacion()
   {
      throw new NotImplementedException();
   }
   
   public void SetFechaModificacion(DateTime newFechaModificacion)
   {
      throw new NotImplementedException();
   }
   
   public DateTime get_fechaEliminacion()
   {
      throw new NotImplementedException();
   }
   
   public void SetFechaEliminacion(DateTime newFechaEliminacion)
   {
      throw new NotImplementedException();
   }
   
   public Oferta()
   {
      throw new NotImplementedException();
   }
   
   /// La IdOferta es el identificador unico de las ofertas dentro del sistema
   public long idOferta;
   public int codigoOferta;
   public DateTime fechaCreacion;
   public DateTime fechaInicio;
   public DateTime fechaFinalzacion;
   public int precio;
   public short isVisible;
   public java.lang.String tituloOferta;
   public java.lang.String descripcionOferta;
   public java.lang.String condiciones;
   public short isDisponible;
   public DateTime fechaModificacion;
   public DateTime fechaEliminacion;
   
   public System.Collections.ArrayList detalleOferta;
   
   /// <summary>
   /// Property for collection of DetalleOferta
   /// </summary>
   /// <pdGenerated>Default opposite class collection property</pdGenerated>
   public System.Collections.ArrayList DetalleOferta
   {
      get
      {
         if (detalleOferta == null)
            detalleOferta = new System.Collections.ArrayList();
         return detalleOferta;
      }
      set
      {
         RemoveAllDetalleOferta();
         if (value != null)
         {
            foreach (DetalleOferta oDetalleOferta in value)
               AddDetalleOferta(oDetalleOferta);
         }
      }
   }
   
   /// <summary>
   /// Add a new DetalleOferta in the collection
   /// </summary>
   /// <pdGenerated>Default Add</pdGenerated>
   public void AddDetalleOferta(DetalleOferta newDetalleOferta)
   {
      if (newDetalleOferta == null)
         return;
      if (this.detalleOferta == null)
         this.detalleOferta = new System.Collections.ArrayList();
      if (!this.detalleOferta.Contains(newDetalleOferta))
      {
         this.detalleOferta.Add(newDetalleOferta);
         newDetalleOferta.Oferta = this;
      }
   }
   
   /// <summary>
   /// Remove an existing DetalleOferta from the collection
   /// </summary>
   /// <pdGenerated>Default Remove</pdGenerated>
   public void RemoveDetalleOferta(DetalleOferta oldDetalleOferta)
   {
      if (oldDetalleOferta == null)
         return;
      if (this.detalleOferta != null)
         if (this.detalleOferta.Contains(oldDetalleOferta))
         {
            this.detalleOferta.Remove(oldDetalleOferta);
            oldDetalleOferta.Oferta = null;
         }
   }
   
   /// <summary>
   /// Remove all instances of DetalleOferta from the collection
   /// </summary>
   /// <pdGenerated>Default removeAll</pdGenerated>
   public void RemoveAllDetalleOferta()
   {
      if (detalleOferta != null)
      {
         System.Collections.ArrayList tmpDetalleOferta = new System.Collections.ArrayList();
         foreach (DetalleOferta oldDetalleOferta in detalleOferta)
            tmpDetalleOferta.Add(oldDetalleOferta);
         detalleOferta.Clear();
         foreach (DetalleOferta oldDetalleOferta in tmpDetalleOferta)
            oldDetalleOferta.Oferta = null;
         tmpDetalleOferta.Clear();
      }
   }
   public System.Collections.ArrayList valoracion;
   
   /// <summary>
   /// Property for collection of Valoracion
   /// </summary>
   /// <pdGenerated>Default opposite class collection property</pdGenerated>
   public System.Collections.ArrayList Valoracion
   {
      get
      {
         if (valoracion == null)
            valoracion = new System.Collections.ArrayList();
         return valoracion;
      }
      set
      {
         RemoveAllValoracion();
         if (value != null)
         {
            foreach (Valoracion oValoracion in value)
               AddValoracion(oValoracion);
         }
      }
   }
   
   /// <summary>
   /// Add a new Valoracion in the collection
   /// </summary>
   /// <pdGenerated>Default Add</pdGenerated>
   public void AddValoracion(Valoracion newValoracion)
   {
      if (newValoracion == null)
         return;
      if (this.valoracion == null)
         this.valoracion = new System.Collections.ArrayList();
      if (!this.valoracion.Contains(newValoracion))
      {
         this.valoracion.Add(newValoracion);
         newValoracion.Oferta = this;
      }
   }
   
   /// <summary>
   /// Remove an existing Valoracion from the collection
   /// </summary>
   /// <pdGenerated>Default Remove</pdGenerated>
   public void RemoveValoracion(Valoracion oldValoracion)
   {
      if (oldValoracion == null)
         return;
      if (this.valoracion != null)
         if (this.valoracion.Contains(oldValoracion))
         {
            this.valoracion.Remove(oldValoracion);
            oldValoracion.Oferta = null;
         }
   }
   
   /// <summary>
   /// Remove all instances of Valoracion from the collection
   /// </summary>
   /// <pdGenerated>Default removeAll</pdGenerated>
   public void RemoveAllValoracion()
   {
      if (valoracion != null)
      {
         System.Collections.ArrayList tmpValoracion = new System.Collections.ArrayList();
         foreach (Valoracion oldValoracion in valoracion)
            tmpValoracion.Add(oldValoracion);
         valoracion.Clear();
         foreach (Valoracion oldValoracion in tmpValoracion)
            oldValoracion.Oferta = null;
         tmpValoracion.Clear();
      }
   }
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
         newTrack.Oferta = this;
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
            oldTrack.Oferta = null;
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
            oldTrack.Oferta = null;
         tmpTrack.Clear();
      }
   }
   public System.Collections.ArrayList imgOferta;
   
   /// <summary>
   /// Property for collection of ImgOferta
   /// </summary>
   /// <pdGenerated>Default opposite class collection property</pdGenerated>
   public System.Collections.ArrayList ImgOferta
   {
      get
      {
         if (imgOferta == null)
            imgOferta = new System.Collections.ArrayList();
         return imgOferta;
      }
      set
      {
         RemoveAllImgOferta();
         if (value != null)
         {
            foreach (ImgOferta oImgOferta in value)
               AddImgOferta(oImgOferta);
         }
      }
   }
   
   /// <summary>
   /// Add a new ImgOferta in the collection
   /// </summary>
   /// <pdGenerated>Default Add</pdGenerated>
   public void AddImgOferta(ImgOferta newImgOferta)
   {
      if (newImgOferta == null)
         return;
      if (this.imgOferta == null)
         this.imgOferta = new System.Collections.ArrayList();
      if (!this.imgOferta.Contains(newImgOferta))
      {
         this.imgOferta.Add(newImgOferta);
         newImgOferta.Oferta = this;
      }
   }
   
   /// <summary>
   /// Remove an existing ImgOferta from the collection
   /// </summary>
   /// <pdGenerated>Default Remove</pdGenerated>
   public void RemoveImgOferta(ImgOferta oldImgOferta)
   {
      if (oldImgOferta == null)
         return;
      if (this.imgOferta != null)
         if (this.imgOferta.Contains(oldImgOferta))
         {
            this.imgOferta.Remove(oldImgOferta);
            oldImgOferta.Oferta = null;
         }
   }
   
   /// <summary>
   /// Remove all instances of ImgOferta from the collection
   /// </summary>
   /// <pdGenerated>Default removeAll</pdGenerated>
   public void RemoveAllImgOferta()
   {
      if (imgOferta != null)
      {
         System.Collections.ArrayList tmpImgOferta = new System.Collections.ArrayList();
         foreach (ImgOferta oldImgOferta in imgOferta)
            tmpImgOferta.Add(oldImgOferta);
         imgOferta.Clear();
         foreach (ImgOferta oldImgOferta in tmpImgOferta)
            oldImgOferta.Oferta = null;
         tmpImgOferta.Clear();
      }
   }
   public System.Collections.ArrayList historialCorreo;
   
   /// <summary>
   /// Property for collection of HistorialCorreo
   /// </summary>
   /// <pdGenerated>Default opposite class collection property</pdGenerated>
   public System.Collections.ArrayList HistorialCorreo
   {
      get
      {
         if (historialCorreo == null)
            historialCorreo = new System.Collections.ArrayList();
         return historialCorreo;
      }
      set
      {
         RemoveAllHistorialCorreo();
         if (value != null)
         {
            foreach (HistorialCorreo oHistorialCorreo in value)
               AddHistorialCorreo(oHistorialCorreo);
         }
      }
   }
   
   /// <summary>
   /// Add a new HistorialCorreo in the collection
   /// </summary>
   /// <pdGenerated>Default Add</pdGenerated>
   public void AddHistorialCorreo(HistorialCorreo newHistorialCorreo)
   {
      if (newHistorialCorreo == null)
         return;
      if (this.historialCorreo == null)
         this.historialCorreo = new System.Collections.ArrayList();
      if (!this.historialCorreo.Contains(newHistorialCorreo))
      {
         this.historialCorreo.Add(newHistorialCorreo);
         newHistorialCorreo.Oferta = this;
      }
   }
   
   /// <summary>
   /// Remove an existing HistorialCorreo from the collection
   /// </summary>
   /// <pdGenerated>Default Remove</pdGenerated>
   public void RemoveHistorialCorreo(HistorialCorreo oldHistorialCorreo)
   {
      if (oldHistorialCorreo == null)
         return;
      if (this.historialCorreo != null)
         if (this.historialCorreo.Contains(oldHistorialCorreo))
         {
            this.historialCorreo.Remove(oldHistorialCorreo);
            oldHistorialCorreo.Oferta = null;
         }
   }
   
   /// <summary>
   /// Remove all instances of HistorialCorreo from the collection
   /// </summary>
   /// <pdGenerated>Default removeAll</pdGenerated>
   public void RemoveAllHistorialCorreo()
   {
      if (historialCorreo != null)
      {
         System.Collections.ArrayList tmpHistorialCorreo = new System.Collections.ArrayList();
         foreach (HistorialCorreo oldHistorialCorreo in historialCorreo)
            tmpHistorialCorreo.Add(oldHistorialCorreo);
         historialCorreo.Clear();
         foreach (HistorialCorreo oldHistorialCorreo in tmpHistorialCorreo)
            oldHistorialCorreo.Oferta = null;
         tmpHistorialCorreo.Clear();
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
               oldRubro.RemoveOferta(this);
            }
            if (value != null)
            {
               this.rubro = value;
               this.rubro.AddOferta(this);
            }
         }
      }
   }
   public Local local;
   
   /// <summary>
   /// Property for Local
   /// </summary>
   /// <pdGenerated>Default opposite class property</pdGenerated>
   public Local Local
   {
      get
      {
         return local;
      }
      set
      {
         if (this.local == null || !this.local.Equals(value))
         {
            if (this.local != null)
            {
               Local oldLocal = this.local;
               this.local = null;
               oldLocal.RemoveOferta(this);
            }
            if (value != null)
            {
               this.local = value;
               this.local.AddOferta(this);
            }
         }
      }
   }

}