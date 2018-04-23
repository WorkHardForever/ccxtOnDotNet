# ccxtOnDotNet - Converting famous python module to .Net(C#)
It's parser for people, who want to use ccxt in their projects
* What is ccxt? https://github.com/ccxt/ccxt

How to use my parser?

--- Install Requirements ---

1. Install IronPython ( http://ironpython.net/download/ )
2. Install Python 2.7 ( https://www.python.org/downloads/ )
3. Visual Studio ( of course :3 )

--- Process ---

1. Install ccxt module through python 2.7:
	python -m pip install ccxt
2. Go to "C:\Python27\Lib\site-packages" and do next:
	a. "C:\Python27\Lib\site-packages\certifi\core.py" <-- Change path in next method:

def where():
    f = os.path.dirname(__file__)

    return os.path.join(f, 'C:\Python27\Lib\site-packages\certifi\cacert.pem')



3. Open "compile.py" file and change paths, output file name and etc.

4. Compile Python code using IronPython:
	--> Run Command Prompt as Administrator
	--> C:\WINDOWS\system32> ipy
	--> Write next code:
		>>> import clr
		>>> clr.CompileModules("compile.dll", "compile.py");

5. Run compiled code:
	--> Run TestIronPython solution by Visual Studio
	--> Change paths, compiled file name and etc.
	--> F5. If you don't catch any exceptions - Congratulations to you!
