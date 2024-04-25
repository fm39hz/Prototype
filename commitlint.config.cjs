module.exports = {
  extends: ["./node_modules/@commitlint/config-conventional"],
  parserPreset: {
    parserOpts: {
      headerPattern: /^(\w*): (.*)$/,
      headerCorrespondence: ["type", "subject"],
    },
  },
  rules: {
    "type-enum": [2, "always", ["feat", "fix", "chore", "style", "refactor"]],
    "header-min-length": [2, "always", 10],
    "header-max-length": [2, "always", 50],
    "body-max-line-length": [2, "always", 72],
    "body-empty": [1, "never"],
    "subject-case": [
      2,
      "never",
      ["sentence-case", "start-case", "pascal-case", "upper-case"],
    ],
  },
};
