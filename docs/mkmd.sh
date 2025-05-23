#!/bin/bash

pushd ..
dirs="avr common cortex cortex-stc drivers p3216 msp430"
# dirs="avr common"
find $dirs -type d | xargs -I % mkdir -p docs/content/%
find $dirs -name '*.f[ts]' | \
  xargs -I % sh -c "sed 's/^\([^\]\)/    \1/;s/\\\ //;s/\\\//;s/    include \(.*\)/[\1](.\/\1.md)\\n/' % >docs/content/%.md"
popd
