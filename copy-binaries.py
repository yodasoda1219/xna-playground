import platform
import shutil
import tarfile
import os
import os.path as path
import tempfile
import subprocess
binary_directories = {
    "Linux": "lib64",
    "Darwin": "osx",
    "Windows": "x64"
}
platform_name = platform.system()
binary_directory = binary_directories[platform_name]
tar = tarfile.open(path.join("vendor", "fnalibs.tar.bz2"), "r")
tempdir = tempfile.TemporaryDirectory()
tempdir_path = path.join(tempdir.name, "fnalibs")
os.makedirs(tempdir_path)
tar.extractall(tempdir_path)
binaries_path = path.join(tempdir_path, binary_directory)
if platform_name == "Linux":
    destination = "/usr/lib64"
    print(f"Copying binaries into {destination}")
    for entry in os.scandir(binaries_path):
        subprocess.call(["sudo", "cp", "-rf", entry.path, destination])
else:
    destination = path.join("XNAPlayground", "bin", "Debug", "net5.0")
    shutil.copytree(binaries_path, destination, dirs_exist_ok=True)
tempdir.cleanup()