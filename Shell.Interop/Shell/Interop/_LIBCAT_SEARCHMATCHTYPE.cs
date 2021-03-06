﻿namespace Microsoft.VisualStudio.Shell.Interop
{
    public enum _LIBCAT_SEARCHMATCHTYPE
    {

        LSMT_WHOLEWORD = 1,

        LSMT_WHOLEWORD_NO_CASE = 2,

        LSMT_LEAF_WHOLEWORD = 4,

        LSMT_LEAF_WHOLEWORD_NO_CASE = 8,

        LSMT_PART_WHOLEWORD = 16,

        LSMT_PART_WHOLEWORD_NO_CASE = 32,

        LSMT_PRESTRING = 64,

        LSMT_PRESTRING_NO_CASE = 128,

        LSMT_LEAF_PRESTRING = 256,

        LSMT_LEAF_PRESTRING_NO_CASE = 512,

        LSMT_PART_PRESTRING = 1024,

        LSMT_PART_PRESTRING_NO_CASE = 2048,

        LSMT_SUBSTRING = 4096,

        LSMT_SUBSTRING_NO_CASE = 8192,

        LSMT_NO_MATCH = 16384,
    }
}
