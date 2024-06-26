var alphabet = 'abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ'.split('');
const Run = (inputlist) => {
    let groupArr = [];
    const total = inputlist.reduce((touti, curr, index) => {
        groupArr.push(curr);
        if (((index + 1) % 3) === 0) {
            return touti + groupArr.shift().split("").reduce((res, v, i, arr) => {
                if (groupArr.every((a) => a.indexOf(v) !== -1))
                {
                    arr.splice(1);
                    groupArr = [];
                    return res + (alphabet.indexOf(v) + 1);
                }
                return res;
            }, 0);
        }
        return touti;
    }, 0);
    console.log(total);
}

Run([
    'LLBPGtltrGPBMMsLcLMMVMpVRhhfCDTwRwRdTfwDllRRRDhC',
    'gNFJHJFgtZFJjZJHNNFWZWZwwDjCwSDhfCDbdwjfwDTTDT',
    'gmQNZnZNHWnqmQpLtVLMBsPpBqrL',
    'HlHldQtHlctzppdQtjdczHhJRnnhGNVmVRJmVjCVFCNh',
    'LgWNgggZJZGFhCZr',
    'DbqPswwMvDPqzlBNHtzfHdwd',
    'tJgtJwwCtNvPHHPtHzDsdRTsBRDDWgWTgT',
    'QhLQjLGjZQFlFZmnmGLDrzWfRldrTrzTBRWTzs',
    'bFFmFZjhSFHvBCvCvJpb',
    'MSGcvnvMGMJgWJDpdndZwBnppfCp',
    'VPVfQQVbshZNZwdNDwNs',
    'LtLbjmQRLmVhQtTbfgWjJgFFcrqqrGSqWg',
    'fHfCNCwwHfGhcntntrrgHrQnrn',
    'FVqpSpbPpjSVMjqvVmVvMzlzwJnbtnnlzQQlrWzJgt',
    'PTqqRRPSRSmqSpPpSpRZwGCLGscCNLZZZTNdNZ',
    'pQQQslVSVzzCQnZSlplzbLcHZHcrrrbZqFbZjbFm',
    'gWtvPgdMDDtFDHHjJJbbccbrLW',
    'MhNvwwDfDfdtvRQnpFNNTlSRSn',
    'ZTnSnTTzqvFmVzvWWm',
    'ClpCgltHNrtgsHdpLCHtDCNLVvQvVwVmwcsWQGMMQvcGcFcv',
    'JmrgCHCNJtlmHmNhnJjnnnjJhPfhSJ',
    'BgRRZTgHHvRTRmRNLNNhQWlmGFfJlWlhsQshpF',
    'qPqSSttwnnzqqqwtVrPwMthFsJllJJlGhpJhWJQlhVQd',
    'MjMwScnDPzcwjtqDtztnctrvgNZTTvCvLgvQbLbvjTBvBg',
    'SWQSbbqTTbPcfMZSwZZwwn',
    'dghjghmNDmGsGgdnfmtMRCLCCRncfc',
    'pJDJNdsNMMhpssgdprBTBzWlpBWlllWb',
    'TwNLNZTwWCWLwWCSTZSLzWHGrDHHPmGdDHvndGdNfvMm',
    'BgpjtpgjBjVbRjQRhVsDnvgGgPnGdrmvnMDfrf',
    'rhRjRssQJplRtVbpthblbbLSLzFCJZFqLLFWCzqcqzLL',
    'PBrdPMtBPvCQBVBjCfWPqSHbszhGGnsfSG',
    'JpmDwJgWJgNzmShhmfSGzh',
    'pRwNcNpFZNZRWgcNplpjVCMVjdvdMQtCMLZjMZ',
    'lDrcnnlLqLRcDDZRLjFVTHzGCLGVPzGPVWGB',
    'pNwHpdmsNJsbpwsbzJTCPWTVFzzQTWCQ',
    'vbhswdtdwfdsmtNSssHwvllvMcZjnjcnZqlgMDZglM',
    'GVVtJGtzVFsVsDTH',
    'mQRgcBRmRLnBjrtFjCCrHmFF',
    'gqpBnlRpgZcvdSdlMdSvMt',
    'tMSCNGSflffNhnnGqlPPsrzWPrTrVpWr',
    'bZHbmDBQmbDZQdbDcRFZZBTTWWWwqVzszWjrFPVwrzqq',
    'HQBLHmQVQLDdCggMfgMNLvNG',
    'HHNDzNJPJPmdPcNGGGhnhwnVhCQBwBjQ',
    'bsSbLfrLtRSLRSRRRsBwhCpfpCzlwCBVjlCV',
    'zvvsvqLtZqLtzRsqTrggRMHJNWJgHHHNJcgWNPdHcH',
    'qgbNvqbgmmZgZLvZqgnZzlpzpzHtVPzttGPrrnnl',
    'jwswGjQDMsQMjdBwdcjCHVtcPVpCVCrPlVSrpc',
    'GsFWBfhGBfDFDFWqNbLNqbgvqbbvfN',
    'HgwWqtcqHNWgnHcNNCfvJCCJJfJGvnPfrR',
    'sbDhZSmdBbsSdmSDdrjjffRvdjPrprCd',
    'vvZbSFFlFHtqFqqWNc',
    'ZRjnbRsHlncZGjTRTfFVSQBQppQvvFBHpF',
    'zrLwMdhDhqJJttDQSldQVPQSlSfPlV',
    'hCWWCzqWnmcZlRRW',
    'HfgfQflHjWgRQRdRBWVsnbvvscbbbwvmbHncSc',
    'tJGLtPPGZPwVvSSPhw',
    'CLGTLZqJtMGqLDFFDZZJFZJpWjRpVNRWpllDpjlBfgVjlp',
    'rhhGZZhLNhPmfJqvfLlq',
    'dHRTHRHQQWcTCRTHmmjJgfqqlGmgWgql',
    'CCwRzTRRdCCRSQwzRcppprZtrMhGBMZMnDSt',
    'WfffvnSnfSBshwsjhlvGlh',
    'ZHpFNTmppVmNzVVmmFMZzbwwjHGrGlPhCGrljbgHsg',
    'pLZMmqVsZVMMVVscDfdtSSStqcRRdn',
    'RhRbLzRLHLCPmzznHLbzCRTJhdTVSJJVSjdFFNFFNTJv',
    'MGgMfpMsBgpnMtGfnfwBtDBjFVdNSSSFdvJSQSpTJdJjNv',
    'lMsBgDMsblmRblnz',
    'ClNcJZttLfLvvRQzQWwRQN',
    'hrpMdqMspsrGDdMphhdMMMMHBmRWmSVrRVzVTzQBQvSmzVWV',
    'ppHDMGhMMDbGMdDMGbgFbgbMlJJnjjZtZfLPcfcngZfPPfCR',
    'ZRslLRgCclZLZzQghQhfrbfGbJ',
    'pVSHpBBBBDVDqDBldVzfrMzQbfSTSJrzzJrJ',
    'DqqHnBDlpNDVVnpnjtDtNjCvFLcsFFPZRcPsNNmPcFcP',
    'LmLWSmSRNdcpcRHFHrWzWHbMbwZlZlPSbTjlwPbTPJTf',
    'DttBsvhnhqvGGBhGtBVNBVqJlPwslMMPJwTjZbbZPTfbPs',
    'CDthQvVNVFCHHWCFdr',
    'RRtCWSzQZdRMrtRWrSztMggcGDfQTcfFTGqTLgGDLc',
    'bnVhnvPHhhdJJBTLDGcDTcBvvD',
    'pmbnhmPPmHwdCjmdrRtCdj',
    'lTPzwhzmHpTvrDCDHJnsNN',
    'tdgtbMMBbWdFbtqJCnsrqnMMDsrq',
    'FjWdtgLSWttWtLSWtDWBjGGmwGlzTRwPTQGhlQQm',
    'wcbnTtTppNLrntznTBBccCGrVldRrZqdqRCZdFZCVZ',
    'JfHDgjgPPfRRgRlLRddR',
    'jhDhhLMfmJjMjDbNSTzbbbtmttmN',
    'CfGlvzpvpTjzzCWjvDlfvbbJbCRSdSRhsSQCMhdbhR',
    'wqrSmrLHHNcLqrrLBNsndssnnhPshnsQwbnJ',
    'NtcmBLcNVDWzjSvWtv',
    'vZPCSCvCJffvVvmCmPqCSlDSscczHDRcwcHzRlRHHs',
    'LFGFNnGrdQttNMFpzpMRRDslsJwsJH',
    'gjtLnFBJrLvhZvCbZhqB',
    'DBcjVFjDhQMSJVZbHZbl',
    'nfmsqppnLfTnfmMmzppwgllSrbSHHtllqbtSwZ',
    'TRzTnfRWnfdzWssfnRfRpncQPBhdDjjDCPcMQcCBGPPj',
    'NSjWCHjNHjpPWPpSFWdtqBMBBFVBvqvJGJwqBt',
    'gQllgDrnhQQDGRshRsZfVtVMRqwMtccVJcBtvRqw',
    'DQrzrDzhQgrsZLrZjWSSHNTWCjjNGTLH',
    'CgdcCFcbTbBzPgmNRmpptP',
    'rsZtsvVvHZZzPmqVNPzNmV',
    'HZjrwrjnjtHSHwDGdFhCdhWWJnWchCFJ',
    'RMTqQMRJqPtBtGBPtWjN',
    'ssHfSfShCwwbhsbHhhsmSfhSGNpCpNCjBBBLptcGtpzBBBWW',
    'HnwrSFwffHsFwrSSjfHglJJlTgZdFdgZRZTDDM',
    'pDLDWlDSlJDmzSJnDScRPLGGvqFqLPccGLgv',
    'CZHfwNMVNjsHNNqPgcbcBbRQGQ',
    'dCffZCjVCdCHHTmnlSgTlTSrlStp',
    'bFtlLCvLlVjpCGPJndrrMMCDDCnrMg',
    'hRsTwcZcBjZRJrfMDnsHrJnH',
    'mNZqcTSSBTScNzVQFtGtjpFtjmGG',
    'bjHdLrHjRWpDCtLzhzps',
    'lZcGfTvQcQfvlqqcNCcBvVwtGzmzthmwmpthMDmswgMt',
    'NcqflNQTBTTvvQSvqSVvQJbHPHbHCRJdndJPSHjWHb',
    'CVmRncrRVrhcmsBgfmtfdJsJmt',
    'bZHvZZDJwpWtdZgtGNGd',
    'vSbwHDMFMJqPQqQvvSPQqpSwjRcTVTLjLRhVCLFLjLFnFzCC',
    'mtffsmBwfwBDBmmsLsHqtpftGrMVMPSMPsVvhNvFrGPMvjNV',
    'TQTQCRWjJcdcQQSPrhhPSvVGPF',
    'cTRJCnldWJZlTgbWgbdbpqfqmppjmtljpqzmjpLw',
    'NNPmrmPWmrSSNNPmnglghmCvLCCflh',
    'LFbsDQMQFtQFHbQHqhvnngCftpcllptJgJ',
    'bDjsGqLLdRVjPZPP',
    'tgrbBQlbtRblwtRGrbCNswDDCsvFszpssCss',
    'SJVMhSZfHvpdhphN',
    'SMLpWZSSZMjfgGBgRtbQgljQ',
    'HsHHNDDHzHDDjsVBBZqtWBrSNcPwQvccvvdhPclSrQSc',
    'fGCFCgpgTfnTmgTFLFgccclhwQhwrzSwSwrCrr',
    'pmLJGfMRpFmfFMzmgGmRpgmVqWJDqZqqHtjBBVDBBqqssJ',
    'mBTfcfCCmpBCCSzNQScQSTfddhdtwgttjghNwGtGdgwGtd',
    'HvvqbvMLnFZVVPjJGRGzGRjZtwgw',
    'VFHFbsFHHSmzQBmsmT',
    'ZNmZCmNHHzzmPPzlbplvhbQh',
    'GDSwldfdvggPfLvQ',
    'ddqrtlnJDJlnjScRmMRCFHTHtFZF',
    'FPvglHSPcpNcFNSHFHNvZjdmbwdbzZtzsHDzbsbj',
    'MMnBLCCWBJCnrCVWCBstTZdZmdTtbDLswTtZ',
    'BMDnRCrnGhPPSgcgpG',
    'nsbgpbdrjMdGqnNRRWWRww',
    'tZZhPzCJhsJBtJPllJBCtCvwwcwwWLvWvwWRThcGcqLq',
    'mlBmZQPZmlppbgMmfssg',
    'RFdZTHFCdvjhgGnFqj',
    'zQLtNQpzNNtNpDtDPWLNMmGfBcjgjlgjhBnvcfnBvfjp',
    'PtmLsPzQVWzWDswCSwHbRZsGZw',
    'nPsfnPsFhTGjqGnmQppG',
    'RZhBbNwbBRZHZSCCHQqSpCpqqm',
    'VMbgNWRWMDfhtFJT',
    'RWhRPDhBHZWgZghRZwZgGJPGdncFdLcdLCjscFcjCjNLLj',
    'mQfSrlfTVqmSVTTTrprfFLqcdLHsLHFnvsFFqnNd',
    'TtQmVHmMrbMWRggRPJZP',
    'TTlCTVTdcpBlcchF',
    'ZLhwSMZhqhtqwqLjFcBvFmvvssGBmmjj',
    'LwSMRtqMHnqhhRZRRtJSVTgggVPdTdrVbQDJgTPW',
    'CGFFWFFVgjfzgVfcJCcgTCcBBWqSqMMBMBShhwMLMwSSMq',
    'fmQnflldltBZqlwqNZpB',
    'dvtnvmtRtsPbzCfTHjHcPzGf',
    'hzshzfshVhthgMmRsFRvFqmm',
    'PDDcZWlWBbplvmRRGtlvqQ',
    'ncjnDjbScnBWZjDVfwjfrrVtwLjzhr',
    'QRWvffVVGfDhNNjzGZLLcGGZ',
    'rgtpSSHpPrHSspvNLFlzTgNLlFglcc',
    'SSpbMHpvmwMQhMBR',
    'dHLtBqPCtPBHNsbRNdNNsZVN',
    'nQwntMwJWhwWjvcjDMlntRsNpgSbNNpglFpVggbSVF',
    'QDhJWwhzJtTqLzCmtT',
    'PSLqTqrCrRvCSJWLdLwdVWdQWL',
    'zNjHQnnHjHznnbDMnMMMdVZcpZZJpZWcdJFZ',
    'BntfgNbzfBtHzgnbbbPPSstlQSSGGrlGsrTT',
    'QpBNsBzztgqVtdmp',
    'jvrhGljRhSTlGGvjwjSwGjRvHVdqLttrMgMbtMMMVmdqqHfV',
    'ChTvTvljmCsQQQnNsQ',
    'CQCNSQHHgCtNHCNHHNDJcBJwLPtJBGhMPPPJwM',
    'zRTqmsdRRzrmdzVRpzPwcjdwwhLjMBMGBBLw',
    'hprmzRmblTzTVTVrlbrmVHNWNnCZFWNNFZlnDFSWgQ',
    'hGGqwwdwMqsRDGRBzlvDzB',
    'LTNTfcCFFFCcNHFFBzRSZRBlzHPSZdvD',
    'nLVTFNfVVLLWnwnwdrdbhnrhrr',
    'hlTpcDTpHmHwDmMbbdMMMGTPdGPR',
    'ZzFqNSQqHvBvzzqjFHtvSGRRMPQsJGJWRGWPMRdRsM',
    'BZjLNqNqzVVHgLVgll',
    'ZHHBzSZPVqghJgSnBhqJRQLRRMvQpwZvfNQRMMMp',
    'ctFCDmdDWmDGNRFMpRlwwQPP',
    'PrsmDmCGjtcmdjGtVqBSjJhnSbHnnghH',
    'QmZHTjmmHRmmdPRvHdVlPdrNNLqWzffbRtqpzfWtWsWNNW',
    'gwMcgnMGFGCjJLqfbtNtzzssCW',
    'DwMFGBwcBFjhBBhcDSJQQVQTPldTvPlVVZQSdQ',
    'NRTGfNffLghStLRR',
    'QlnWsdJWmnbWnVqWbWqHPSpmjgCjtSwhPjgtptLS',
    'JWchnllHqQJzGTZfTcFNDN',
    'VtdtcTVVCRctVdJclCVtpphpPhNGDwNPmThwWmgG',
    'ZjZMFnfBqqMjHZHMzBnzgPGwDmhmhDPfQNGPQGfD',
    'BbgsnFgMgMlVdJtlcVSs',
    'tlBMdBnClhLJnTbgph',
    'PhDDczqDGPqsHGrRGPWHGPzcFJNLTTJZLNbNLfFZgTbffL',
    'sHsmzzrGmPrRDRHqhHwmjBVtllwtdMdBSBtl',
    'QscfZsGsVjVtqGmlzvRMvl',
    'ThJNCHPTDDhHHJTJPHmlSMTtTTlBvlnMSzqn',
    'HhCdrHrCcpmmdVmb',
    'WPPBPvRWzvhWhWzGWtBqBSTLDZhgFSTCDgSgZZDCZs',
    'flbJmMJnjdMqNdfZZrFZZNFZgrrsTZ',
    'nQnqJlJdlQMMbVnVmdMplVnnBwcBPGttzQcvtHcWwWtHRHvB',
    'LLsmpJTWCJmJppCmgHCCLjbFtRFghzjfjcjcZttbRg',
    'SZlMPBdBtQfFSbSF',
    'nPqldlDwlBVnvdLWJVsmVNZCCVmJ',
    'HWvNVtHWJjHJsSgHsHzsDsmf',
    'RwZGPFGMQgzpTGSD',
    'PZMlwwqhFPPZqwFhPwnFbMjWJNNBtWNVJlCJJWJjWWzj',
    'frBSzJDtztfNVGwRzVgGhqsV',
    'MPMmjPWGMMmPCQCcbmRwVhTgVwTTqjvRTLww',
    'cFpcMGFplDHfBHFS',
    'gtjhjLffmgjgmbgVfbNdqFJMJMNbbwrwqq',
    'sWHHPSJsHzTZzTGsCdrqCNNddGdGFGRC',
    'ZpzHHTZWzsSSnBBPsTBnLVcpQfcJcQVQDQfcDfQt',
    'qMPqChqjQPRCMqlBrmGmLbPSsTbSvz',
    'nWNHZFVZZttWpfHsGSbBGTbWBSGmSm',
    'nZfpVfdZdtFHnwVHZtNwZhCJRJhcCdDcQhCqDSSCQc',
    'LlwSlZrftFSMpfLCdltTmmmSDmJqmssDVJBmJB',
    'cRcGGhpvDTmTDgsG',
    'nNPcjpWbNzjRRcWhbzWjvnLMddMLCwtdtMttddtrCdMz',
    'NszSsDCMSDzdZpCMCSMpNszfTvJhlvmlmrTfrhlhHPrmhD',
    'FRWBgRjWwqFWQFBBWjVncjRTvJfvvJvVrHhmVrHhmrdJTh',
    'wnwnqwRGFqdbNNtCGpCp',
    'zgsBvPVVDDrDtDgt',
    'nTHldmJQNTTfflcJNrQlHWpmDDFDFhWpWCLtFbphCm',
    'nTTNMlNfHQZTQPGSzVVZSVPSwr',
    'bPLbtPpwsJhlpnhnnLNNZDWhRNzWQrWWffNr',
    'SczqFdFHSTFjmMSMFVqFGCWWNRrWQQQRZCVWgQQgrZ',
    'dFdzFGHvjmqGMFwwLLsPnvBspnsn',
    'lwJwwmblVdvjbbbJvVnlmjGTTNTLqffpqDJffqGLqDLD',
    'ZtWgPtRMtQRQnTGDQNTTqL',
    'gCztMgWgchHhvwlllbnl',
    'cCwSSCVbqwCCWSbZMmGdtBllWBfdlvdt',
    'jzRsJjhPjnLthJNNpmpvmvvMfGvjQpGv',
    'nPHPFgRHLtCHZrqTcq',
    'dVJwCJGCVrQQGTNtLtGm',
    'hWWgDHBzWWWpZlhWBssLDTDsQTLLtswswL',
    'gPhBHpjwHcljpggwwWqvbFvdCVRqPPnnqVRb',
    'zRRRRNqzpQZNNRRmRcZscQcCDmCTTTDGfTbfGhrTCTrbFF',
    'HMvMtjgtLHVlLVfhCGfrfhJhhrvh',
    'LBgStjnHBjLVgggBgHndnSNNQdNWcQQNGZccwsccdQpw',
    'jLRqmZNGtZtvZvHzPfCvSSzhCP',
    'QbwDVHFrVbDVrDFbzPwSThSfddhWPWzS',
    'rpnFDccHFHtZNmMmRntj',
    'RFVdzzlNtrwSTltb',
    'hHGcqqBcGLQZffHhMwSswSWGrnnbMStC',
    'cgqLBgQgpgbbPbPz',
    'lfcgglhfTvmlBvclbgztnSRtSmttwRJwptWR',
    'FMjDjsdNDjNMQLFFLCMQdtwGGzRwzpGwzdWzzJpGhn',
    'ZQVNsVZMPsVhCQsFCFsHHlqlcBZrHHfBflbHBB',
    'vGGQQdwNCTJfQJHJbM',
    'FFqmzghlzhgqjlFqzZhmhPlRgBDLLRTTcHMbRcJHBLcgRH',
    'qFrPjnhZmqnhZZjhhmpPzZmtvbpwtdvsSCCsGwdNwvwNCp',
    'nrFdSHScdRwvdvRm',
    'NNpPLJJbNbppCvmzbHTbmsTw',
    'fWLHPlPtpMNBgGQgqggQSMGc',
    'BcHtrBcnjflfHslsrnltbTgvMwpWnnWpwwwCwCCRRW',
    'dzGhLSSGDdPNgLLdPWTqWWRMqwRWpvzMMv',
    'VPZZNhhNSSDhLNSLdFZBVgBbjHcgsgfrbBJbfs',
    'VMnWjjWTnNNCzzhblbbjlj',
    'FmHwfFHqpDrJzPQLPLbCDs',
    'GrdFfHqqSmmwHSqHfpdMNTtTtZCMMZtTRggGZR',
    'QRlnlTphqNfqdjZNmd',
    'rDtPmGctFrcgDjJcNjvNJNCcNw',
    'bgGDtgDbBWBSBVlblmVmsRMmLM',
    'CcQTQTrrmfQQhZZBpZpSSZ',
    'JFqSvLlLbWggDvDDFHjsdnshBZpjHBBhBW',
    'FgJqNvLRMlMMDDblrtfrTCStmCVtNttz',
    'MRRbbddqtHbMZbqMHHTFTFgwZglWPfgsZWgW',
    'LCcLjzCNGNcvpvLTFPmzlFsfTgFlgs',
    'NhNGcrCGrsrvcDpvVcSbtHQJQbnQbSdHMtJV',
    'bfMfBFcWFsWZHBWRPQpRqdwmMpmddm',
    'rSShvvVTNVhvVCCvThDlSvCwpGCmRmGQmPwmpLRLRdpq',
    'DhRzzVNVVgSzTFcgtnbHnHbfBB',
    'HsTGHHvlvvGTGlHBvlbZstrVrwNjrjVStwVVZR',
    'PPmgcFJPFcFWmWMgdNtVtQZtDVDVdZZjjR',
    'LLqWnMnmNvlBLCTzCT',
    'qTttLqLvGCQqCDlhml',
    'FJjzrRBrpjRWrCwrBrrwpRbbDzgghSmmNhPQhgNshmDSzSNm',
    'bJBrbFRjBVnWBrRBnHLfHGfdVtvHttcCdT',
    'mTzjGPmPPmPNjNBTvlJRlNJzZqrzrSZZSpcZqpgcgcggFr',
    'QWCwwMwWWhVZFbpQDSpSJS',
    'stMMsWwMwVWtwJTNNPvvRmTsNPsl',
    'gGFFNWMMNFTBlLpGpSll',
    'qvccssdDwDbhMhzwHLppTSHLrdBpBVLV',
    'PhJhzhMJzwDJwhZZtZQJCjgWtFjZ',
    'pGqWfqqGcspGqWqppHprpTrzhCzttMBCtbtJmtJbSBvWBt',
    'QDnVPgVPgDCJBMhmBJgv',
    'NlZwFlnnPLLlFwDlDlnPPFFHTMTdMZjTTcjsqqcsdfGdcp',
    'HLzZfHWWQwpgVHjVHr',
    'JlMlMGGDMtJGdtJhqtlccDgVCSTFFSCSDTggpvFTjSgS',
    'JcGRMlthtlVNMJRfzWsPnQsnnZNZns',
    'zVfvMpsbtQmtBlFWBZ',
    'lLSrlNTNRSFRFhhHRmPR',
    'dnSJjjwJJGwwnzVlvpszvccM',
    'SmlcCrpnrnznGzSBBSfzNbtsQsWZQcFbWctcbbZb',
    'JHgwJPjvdghbbWdDZGNLZb',
    'JjghvvhRwhwJVhHTzmfRfzGSMrzBfnGC',
    'JbCmrbnzmntnVJjbCHJJFQFvqgJgQgqLDQ',
    'NGhhhhPMGhWsSSchWlNsCLBBlLFQCgqvgCFFgQBg',
    'PdcNWWcdGdPssPPNTSNNtzbTwjntzbbVwtZpCVnb',
    'tGNgtsNQHsJmwwzddmQw',
    'hMhhDBwMhDDfCRRBjFDDTTWjdWmrmdWqjlmmmjJz',
    'RSpSSBhppDhRncRLswZLGvtGvNcNtL'
]);