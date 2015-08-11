rem
rem  You can simplify development by updating this batch file and then calling it from the 
rem  project's post-build event.
rem
rem  It copies the output .DLL (and .PDB) to LINQPad's drivers folder, so that LINQPad
rem  picks up the drivers immediately (without needing to click 'Add Driver').
rem
rem  The final part of the directory is the name of the assembly plus its public key token in brackets.

xcopy /i/y Spiral.LinqPad.Lucene.* "%programdata%\LINQPad\Drivers\DataContext\4.0\Spiral.LinqPad.Lucene (889f9d68e0eaea72)\"
