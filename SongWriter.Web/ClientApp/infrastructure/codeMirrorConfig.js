import CodeMirror from 'codemirror';

const configure = function () {
    CodeMirror.defineMode('songwriter', () => {
        return {
            token(stream, state) {
                var ch = stream.peek();

                // Handle Comments
                if (stream.sol()) {
                    if (ch === "!") {
                        stream.next();
                        if (stream.eol()) {
                            return 'start-annotation';
                        }
                        else {
                            return 'marker-annotation';
                        }
                    }
                    else if (ch === "@") {
                        stream.next();
                        if (stream.eol()) {
                            return 'start-chord';
                        }
                        else {
                            return 'marker-chord';
                        }
                    }
                    else if (ch === "#") {
                        stream.next();
                        if (stream.eol()) {
                            return 'start-lyric';
                        }
                        else {
                            return 'marker-lyric';
                        }
                    }
                }
                else {
                    // Go back one line, should be safe since we know we're not at the SOL
                    stream.backUp();
                    var ch = stream.peek();

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

                    stream.next()
                    return null
                }
            }
        }
    });
}


export default configure;
