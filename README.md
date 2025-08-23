# CLIExplorer 👁️

A file **explorer** for **CLI**. This program mostly relies on re-implementations of basic UNIX commands in C# and makes your life easier!

## Documentation

All implemented commands are simple and straightforward to use.

| Command                             | Description                                                                 |
| ----------------------------------- | --------------------------------------------------------------------------- |
| `ls`                                | Lists all directories and files in the **current working directory (cwd)**. |
| `cwd`                               | Prints current working directory.                                           |
| `cd <dir>`                          | Changes current working directory.                                          |
| `echo <string>`                     | Prints everything written after the command prefix (echo).                  |
| `cp <sourcePath> <destinationPath>` | Copies file/directory in the source path to destination path.               |
| `mkdir <(abs/relative)path>`        | Creates directory to given path.                                            |
| `rmdir <(abs/relative)path>`        | Removes directory from given path.                                          |
| `mv <sourcePath> <destinationPath>` | Moves file/directory in source path to destination path.                    |
| `exit`                              | Exits from program.                                                         |
| `clear`                             | Clears terminal.                                                            |

### Variable Expansion

Replaces every `${<command>}` string with the output of that `<command>`.

> Note: This feature is only works on cwd. Because it would be illogical to use it with other commands.

**Example**:
```commandline
(C:\Users\vortique) $ cwd
C:\Users\vortique
(C:\Users\vortique) $ echo test ${cwd}
test C:\Users\vortique
```

## Roadmap

Here are the upcoming features planned for future versions:

- [x] `cwd` (current working directory) command
- [x] Variable expansion (`${cwd}` -> Environment.CurrentDirectory)
- [x] `cd` command
- [x] `cp` command
- [x] `mv` command
- [ ] `grep` command
- [ ] *...and endless ideas in my brain.* 🚀

## License

This project licensed under This project is licensed under the [GPL v3.0](LICENSE.txt) license..