// File:    Consumidor.cs
// Author:  Ian Cardenas
// Created: miércoles, 6 de septiembre de 2017 13:43:07
// Purpose: Definition of Class Consumidor

using System;

public class Consumidor
{
   protected void Finalize()
   {
      throw new NotImplementedException();
   }
   
   public long GetIdConsumidor()
   {
      throw new NotImplementedException();
   }
   
   public void SetIdConsumidor(long newIdConsumidor)
   {
      throw new NotImplementedException();
   }
   
   public int GetRut()
   {
      throw new NotImplementedException();
   }
   
   public void SetRut(int newRut)
   {
      throw new NotImplementedException();
   }
   
   public java.lang.String GetDv()
   {
      throw new NotImplementedException();
   }
   
   public void SetDv(java.lang.String newDv)
   {
      throw new NotImplementedException();
   }
   
   public java.lang.String GetNombre()
   {
      throw new NotImplementedException();
   }
   
   public void SetNombre(java.lang.String newNombre)
   {
      throw new NotImplementedException();
   }
   
   public java.lang.String GetApellidos()
   {
      throw new NotImplementedException();
   }
   
   public void SetApellidos(java.lang.String newApellidos)
   {
      throw new NotImplementedException();
   }
   
   public java.lang.String GetCorreo()
   {
      throw new NotImplementedException();
   }
   
   public void SetCorreo(java.lang.String newCorreo)
   {
      throw new NotImplementedException();
   }
   
   public java.lang.String GetContrasena()
   {
      throw new NotImplementedException();
   }
   
   public void SetContrasena(java.lang.String newContrasena)
   {
      throw new NotImplementedException();
   }
   
   public short GetRecibirOferta()
   {
      throw new NotImplementedException();
   }
   
   public void SetRecibirOferta(short newRecibirOferta)
   {
      throw new NotImplementedException();
   }
   
   public DateTime get_fechaRegistro()
   {
      throw new NotImplementedException();
   }
   
   public void SetFechaRegistro(DateTime newFechaRegistro)
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
   
   public short GetIsActivo()
   {
      throw new NotImplementedException();
   }
   
   public void SetIsActivo(short newIsActivo)
   {
      throw new NotImplementedException();
   }
   
   public Consumidor()
   {
      throw new NotImplementedException();
   }
   
   public long idConsumidor;
   public int rut;
   public java.lang.String dv;
   public java.lang.String nombre;
   public java.lang.String apellidos;
   public java.lang.String correo;
   public java.lang.String contrasena;
   public short recibirOferta;
   public DateTime fechaRegistro;
   public DateTime fechaModificacion;
   public DateTime fechaEliminacion;
   public short isActivo;
   
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
         newValoracion.Consumidor = this;
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
            oldValoracion.Consumidor = null;
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
            oldValoracion.Consumidor = null;
         tmpValoracion.Clear();
      }
   }
   public System.Collections.ArrayList certificado;
   
   /// <summary>
   /// Property for collection of Certificado
   /// </summary>
   /// <pdGenerated>Default opposite class collection property</pdGenerated>
   public System.Collections.ArrayList Certificado
   {
      get
      {
         if (certificado == null)
            certificado = new System.Collections.ArrayList();
         return certificado;
      }
      set
      {
         RemoveAllCertificado();
         if (value != null)
         {
            foreach (Certificado oCertificado in value)
               AddCertificado(oCertificado);
         }
      }
   }
   
   /// <summary>
   /// Add a new Certificado in the collection
   /// </summary>
   /// <pdGenerated>Default Add</pdGenerated>
   public void AddCertificado(Certificado newCertificado)
   {
      if (newCertificado == null)
         return;
      if (this.certificado == null)
         this.certificado = new System.Collections.ArrayList();
      if (!this.certificado.Contains(newCertificado))
      {
         this.certificado.Add(newCertificado);
         newCertificado.Consumidor = this;
      }
   }
   
   /// <summary>
   /// Remove an existing Certificado from the collection
   /// </summary>
   /// <pdGenerated>Default Remove</pdGenerated>
   public void RemoveCertificado(Certificado oldCertificado)
   {
      if (oldCertificado == null)
         return;
      if (this.certificado != null)
         if (this.certificado.Contains(oldCertificado))
         {
            this.certificado.Remove(oldCertificado);
            oldCertificado.Consumidor = null;
         }
   }
   
   /// <summary>
   /// Remove all instances of Certificado from the collection
   /// </summary>
   /// <pdGenerated>Default removeAll</pdGenerated>
   public void RemoveAllCertificado()
   {
      if (certificado != null)
      {
         System.Collections.ArrayList tmpCertificado = new System.Collections.ArrayList();
         foreach (Certificado oldCertificado in certificado)
            tmpCertificado.Add(oldCertificado);
         certificado.Clear();
         foreach (Certificado oldCertificado in tmpCertificado)
            oldCertificado.Consumidor = null;
         tmpCertificado.Clear();
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
         newTrack.Consumidor = this;
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
            oldTrack.Consumidor = null;
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
            oldTrack.Consumidor = null;
         tmpTrack.Clear();
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
         newHistorialCorreo.Consumidor = this;
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
            oldHistorialCorreo.Consumidor = null;
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
            oldHistorialCorreo.Consumidor = null;
         tmpHistorialCorreo.Clear();
      }
   }

}