﻿using System;

namespace DesignPatternsTut.SolidDesignPrinciples
{
  public class Document
  {

  }

  //---------------------------------------------------------------------------

  public interface IMachine
  {
    void Print( Document d );
    void Scan( Document d );
    void Fax( Document d );
  }

  //---------------------------------------------------------------------------


  public interface IPrinter
  {
    void Print( Document d );
  }

  //---------------------------------------------------------------------------

  public interface IScanner
  {
    void Scan( Document d );
  }

  //---------------------------------------------------------------------------

  public class PhotoCopier : IPrinter, IScanner
  {
    public void Print( Document d )
    {
      throw new NotImplementedException();
    }

    public void Scan( Document d )
    {
      throw new NotImplementedException();
    }
  }

  //---------------------------------------------------------------------------

  public interface IMultiFunctionDevice : IScanner, IPrinter //...
  {

  }

  //---------------------------------------------------------------------------

  public class MultiFunctionMachine : IMultiFunctionDevice
  {
    private IPrinter printer;
    private IScanner scanner;

    public MultiFunctionMachine( IPrinter printer, IScanner scanner )
    {
      this.printer = printer;
      this.scanner = scanner;
    }

    // Decorator pattern
    public void Print( Document d )
    {
      printer.Print( d );
    }

    public void Scan( Document d )
    {
      scanner.Scan( d );
    }
  }

  //---------------------------------------------------------------------------

  public class MultifunctionPrinter : IMachine
  {
    public void Print( Document d )
    {
      //
    }

    public void Scan( Document d )
    {
      //
    }

    public void Fax( Document d )
    {
      //
    }
  }

  //---------------------------------------------------------------------------

  public class OldFashionedPrinter : IMachine
  {
    public void Print( Document d )
    {
      //
    }

    public void Scan( Document d )
    {
      throw new NotImplementedException();
    }

    public void Fax( Document d )
    {
      throw new NotImplementedException();
    }
  }

  //---------------------------------------------------------------------------
}
