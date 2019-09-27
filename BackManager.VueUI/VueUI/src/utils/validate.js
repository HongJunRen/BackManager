export const isValidUsername = (str) => ['admin', 'editor'].indexOf(str.trim()) >= 0;
export const isExternal = (path) => /^(https?:|mailto:|tel:)/.test(path);
//# sourceMappingURL=validate.js.map