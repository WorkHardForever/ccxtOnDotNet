from System import IO
from System.IO.Path import Combine
from System.Text.RegularExpressions import Regex

def walk(folder):
    for file in IO.Directory.GetFiles(folder):
        if (Regex.IsMatch(file, "\.pyc") or not Regex.IsMatch(file, "\.py")):
            continue
        yield file
    for folder in IO.Directory.GetDirectories(folder):
        if (Regex.IsMatch(folder, "async")):
            continue
        for file in walk(folder):
            yield file

folder = r"C:\Python27\Lib\site-packages"
all_files = list(walk(Combine(folder, 'ccxt')))
all_files.extend(walk(Combine(folder, 'requests')))
all_files.extend(walk(Combine(folder, 'urllib3')))
all_files.extend(walk(Combine(folder, 'chardet')))
all_files.extend(walk(Combine(folder, 'certifi')))
all_files.extend(walk(Combine(folder, 'idna')))

print(folder)
print(all_files)

output = r"C:\Users\Edhar_Menhel\Desktop"

import clr
clr.CompileModules(Combine(output, "ccxt.dll"), *all_files)
