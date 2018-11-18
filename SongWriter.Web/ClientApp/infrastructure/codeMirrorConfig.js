import CodeMirror from 'codemirror';

CodeMirror.defineMode('songwriter', () => {
    return {
        token(stream, state) {
            var ch = stream.peek();


            // Handle Comments
            if (stream.sol()) {
                if (stream.match("[")) {
                    while ((ch = stream.next()) != null)
                        if (ch == "]") {
                            stream.eat("]");
                            return "section";
                        }
                }
                else {
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

                stream.next()
                return null
            }
            else {
                // Go back one char, should be safe since we know we're not at the SOL
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

                stream.skipToEnd()
                return null
            }
        }
    }
});




