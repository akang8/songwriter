import CodeMirror from 'codemirror';

const configure = function () {
    CodeMirror.defineMode('songwriter', () => {
        return {
            token(stream, state) {
                var ch = stream.peek();

                // Handle Comments
                if (ch === "!") {
                    if (stream.sol()) {
                        stream.skipToEnd();
                        return 'annotation';
                    }
                }
                else if (ch === "@") {
                    if (stream.sol()) {
                        stream.skipToEnd();
                        return 'chord';
                    }
                }
                else if (ch === "#") {
                    if (stream.sol()) {
                        stream.skipToEnd();
                        return 'lyric';
                    }
                }
                else {
                    stream.next()
                    return null
                }
            }
        }
    });
}


export default configure;
