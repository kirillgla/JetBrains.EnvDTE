﻿namespace EnvDTE90
{
    public interface Template
    {
        string ID { get; }
        string Name { get; }
        string Description { get; }
        string FilePath { get; }
        string BaseName { get; }
        string CustomDataSignature { get; }
        string CustomData { get; }
    }
}
