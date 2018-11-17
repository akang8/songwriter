import CodeMirror from 'codemirror';

const configure = function () {
    CodeMirror.defineMode('songwriter', () => {
        return {
            token(stream, state) {
                var ch = stream.peek();

                // Handle Comments
                if (ch === "!") {
                    stream.skipToEnd();
                    return 'annotation';
                }
                else if (ch === "@") {
                    stream.skipToEnd();
                    return 'chord';
                }
                else if (ch === "#") {
                    stream.skipToEnd();
                    return 'lyric';
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
