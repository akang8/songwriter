import CodeMirror from 'codemirror';

const configure = function () {
    CodeMirror.defineMode('mymode', () => {
        return {
            token(stream, state) {
                var ch = stream.peek();

                // Handle Comments
                if (ch === "!") {
                    stream.skipToEnd();
                    return 'comment';
                }
                else if (ch === "@") {
                    stream.skipToEnd();
                    return 'number';
                }
                else if (ch === "#") {
                    stream.skipToEnd();
                    return 'operator';
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
