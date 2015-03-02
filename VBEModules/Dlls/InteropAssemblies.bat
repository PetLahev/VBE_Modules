@ECHO OFF
"C:\Program Files (x86)\Microsoft SDKs\Windows\v7.0A\Bin\tlbimp.exe" ^
   "C:\Program Files (x86)\Common Files\DESIGNER\MSADDNDR.DLL" ^
   /out:"VBEModules.Interop.Extensibility.dll" ^
   /keyfile:"c:\Users\PetLahev\Documents\Visual Studio 2010\Projects\VBEModules\VBEModules\VBEModules.snk" ^
   /strictref:nopia /nologo /asmversion:1.0.0.0 /sysarray

PAUSE
CLS

"C:\Program Files (x86)\Microsoft SDKs\Windows\v7.0A\Bin\tlbimp.exe" ^
   "C:\windows\syswow64\stdole2.tlb" ^
   /out:VBEModules.Interop.Stdole.dll ^
   /keyfile:"c:\Users\PetLahev\Documents\Visual Studio 2010\Projects\VBEModules\VBEModules\VBEModules.snk" ^
   /strictref:nopia /nologo /asmversion:1.0.0.0

PAUSE
CLS

"C:\Program Files (x86)\Microsoft SDKs\Windows\v7.0A\Bin\tlbimp.exe" ^
   "c:\Program Files (x86)\Common Files\microsoft shared\OFFICE14\MSO.DLL" ^
   /out:VBEModules.Interop.Office12.dll ^
   /keyfile:"c:\Users\PetLahev\Documents\Visual Studio 2010\Projects\VBEModules\VBEModules\VBEModules.snk" ^
   /strictref:nopia /nologo /asmversion:1.0.0.0 ^
   /reference:VBEModules.Interop.Stdole.dll

PAUSE
CLS

"C:\Program Files (x86)\Microsoft SDKs\Windows\v7.0A\Bin\tlbimp.exe" ^
   "C:\Program Files (x86)\Common Files\Microsoft Shared\VBA\VBA6\vbe6ext.olb" ^
   /out:VBEModules.Interop.VBAExtensibility.dll ^
   /keyfile:"c:\Users\PetLahev\Documents\Visual Studio 2010\Projects\VBEModules\VBEModules\VBEModules.snk" ^
   /strictref:nopia /nologo /asmversion:1.0.0.0 ^
   /reference:VBEModules.Interop.Office12.dll

PAUSE