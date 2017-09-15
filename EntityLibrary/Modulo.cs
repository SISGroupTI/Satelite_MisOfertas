// File:    Modulo.cs
// Author:  Ian Cardenas
// Created: miércoles, 6 de septiembre de 2017 13:43:07
// Purpose: Definition of Class Modulo

using System;
using System.Collections;

public class Modulo
{
    private long idModulo;
    private String nombre_modulo;

    public long IdModulo { get => idModulo; set => idModulo = value; }
    public string Nombre_modulo { get => nombre_modulo; set => nombre_modulo = value; }

    public Modulo(long idModulo, string nombre_modulo)
    {
        this.idModulo = idModulo;
        this.nombre_modulo = nombre_modulo;
    }

    public Modulo()
    {
    }
}